using System;
using System.Collections.Generic;
using System.Reflection;
using Angalia.Core.Models;
using Angalia.Core.Services;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.RestClient;
using Intersoft.Crosslight.UI.Core;
using Newtonsoft.Json;
using StreamExtensions = Angalia.Core.Extensions.StreamExtensions;

namespace Angalia.Core.ViewModels.Markers
{
    public class CustomMarkerViewModel : MapViewModelBase
    {
        #region Constructors

        public CustomMarkerViewModel()
        {
            this.Title = "Nearby Hospitals";
        }

        #endregion

        #region Properties
        

        #endregion
        
        public override async void Navigated(NavigatedParameter parameter)
        {
            var storageService = ServiceProvider.GetService<ILocalStorageService>();
            var activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();
            var factoryAsync = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();

            var db = factory(storageService.GetFilePath(MessageFactory.DatabaseName.Value, LocalFolderKind.Data));
            var dba = factoryAsync(storageService.GetFilePath(MessageFactory.DatabaseName.Value, LocalFolderKind.Data));

            var count = await dba.Table<Hospital>().CountAsync();
            var setting = await dba.Table<Settings>().FirstOrDefaultAsync();
            var hradius = setting.HospitalNearbyRadius;
            HospitalResponse r;

            this.ActivityPresenter.Show("Acquiring location...");

            if (count == 0)
            {
                IRestClient client = new RestClient("http://174.142.15.209:5000/minto/hooks/angalia/apps/v1/facility/all/");
                var request = new RestRequest("hospitals.json", HttpMethod.GET);
                var response = await client.ExecuteAsync(request);
                r = JsonConvert.DeserializeObject<HospitalResponse>(response.Content);
                if (r.Status)
                {
                    var tot = r.Hospitals.Count;
                    if (tot > 0)
                    {
                        await dba.InsertAllAsync(r.Hospitals);
                    }
                }
                else
                {
                    ToastPresenter.Show(r.Message);
                }
            }

            this.MobileService.Location.GetCurrentLocation(LocationAccuracy.Best, async (locationResult) =>
            {
                this.ActivityPresenter.Hide();

                if (locationResult.Error == null)
                {
                    var hospitals = await dba.Table<Hospital>().ToListAsync();
                    var list = new List<MedicalPlace>();
                    foreach (var item in hospitals)
                    {
                        var lc = new LocationCoordinate(item.Latitude, item.Longitude);
                        var isNear = this.MobileService.Location.IsLocationInRange(lc, locationResult.Location.Coordinate, hradius);
                        if (isNear)
                        {
                            PlacemarkAddress pa = new PlacemarkAddress();
                            pa.Country = "GHANA";
                            pa.City = $"{item.Town}, {item.District}";
                            pa.State = item.Region;
                            pa.Street = item.Address;
                            pa.Zip = "00233";
                            var loc = new Location(lc);
                            var mp = new MedicalPlace(loc, pa, item.Name);
                            mp.MarkerImage = StreamExtensions.ToByte(this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlaceType.hospital.png"));
                            list.Add(mp);
                        }
                    }
                    this.Markers = list.ToObservable();
                    this.CameraSettings = new CameraSettings(MapRectBounds.Create(this.Markers))
                    {
                        Padding = 50,
                        EnableAnimation = true
                    };
                    this.ToastPresenter.Show("My location is at " + locationResult.Location.Coordinate.Latitude + "," + locationResult.Location.Coordinate.Longitude);

                }
                else
                    this.MessagePresenter.Show("Unable to acquire location due to error '" + locationResult.Error.ToString() + "'");
            });            
            
            base.Navigated(parameter);
        }
    }

    public class NearbyHospitalRequestModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
    }

}
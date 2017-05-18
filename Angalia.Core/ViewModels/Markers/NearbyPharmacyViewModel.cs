using System;
using System.Collections.Generic;
using System.Reflection;
using Angalia.Core.Extensions;
using Angalia.Core.Models;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.RestClient;
using Intersoft.Crosslight.UI.Core;
using Newtonsoft.Json;

namespace Angalia.Core.ViewModels.Markers
{
    public class NearbyPharmacyViewModel : MapViewModelBase
    {
        #region Constructors

        public NearbyPharmacyViewModel()
        {
            this.Title = "Nearby Pharmacies";
        }

        #endregion

        #region Properties

        private double latit;
        private double longit;


        #endregion

        public override async void Navigated(NavigatedParameter parameter)
        {
            this.ActivityPresenter.Show("Acquiring location...");
            this.MobileService.Location.GetCurrentLocation(LocationAccuracy.Best, (locationResult) =>
            {
                this.ActivityPresenter.Hide();

                if (locationResult.Error == null)
                {
                    latit = locationResult.Location.Coordinate.Latitude;
                    longit = locationResult.Location.Coordinate.Longitude;
                    this.MessagePresenter.Show("My location is at " + locationResult.Location.Coordinate.Latitude + "," + locationResult.Location.Coordinate.Longitude);

                }
                else
                    this.MessagePresenter.Show("Unable to acquire location due to error '" + locationResult.Error.ToString() + "'");
            });

            MessagePresenter.Show("latitude: " + latit + ", longitude: " + longit);
            try
            {
                this.ActivityPresenter.Show("Loading..", ActivityStyle.SmallIndicatorWithText, true);

                IRestClient client = new RestClient("http://api.angaliagh.com/hooks/angalia/apps/v1/facility/nearby/");
                var request = new RestRequest("pharmacies.json", HttpMethod.POST) { RequestFormat = RequestDataFormat.Json };
                request.AddBody(new NearbyPharmacyRequestModel { radius = 1000, latitude = latit, longitude = longit });
                var response = await client.ExecuteAsync(request);
                var r = JsonConvert.DeserializeObject<PharmacyResponse>(response.Content);

                if (r.Status)
                {
                    var list = new List<MedicalPlace>();
                    var lat = 0.0;
                    var lon = 0.0;
                    var tot = r.Pharmacies.Count;
                    foreach (var item in r.Pharmacies)
                    {
                        lat += item.Latitude;
                        lon += item.Longitude;
                        PlacemarkAddress pa = new PlacemarkAddress();
                        pa.Country = "GHANA";
                        pa.City = item.Town;
                        pa.State = item.Region;
                        pa.Street = item.Address;
                        pa.Zip = "00233";
                        var loc = new Intersoft.Crosslight.Mobile.Location(new LocationCoordinate(item.Latitude, item.Longitude));
                        var mp = new MedicalPlace(loc, pa, item.Name);
                        mp.PhoneNumber = item.Telephone;
                        mp.CountryCode = "233";
                        mp.Name = item.Name;
                        mp.Type = new MedicalPlaceType { Name = item.Type } ;
                        mp.MarkerImage = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlaceType.pharmacy.png").ToByte();
                        list.Add(mp);
                    }
                    this.Markers = list.ToObservable();
                    this.CameraSettings = new CameraSettings(new MapRectBounds(new LocationCoordinate(lat/tot, lon/tot), 0.03))
                    {
                        EnableAnimation = true,
                        Padding = 50
                    };
                }
                else
                {
                    MessagePresenter.Show(r.Message);
                }
            }
            catch (Exception ex)
            {
                MessagePresenter.Show(ex.Message);
            }
            finally
            {
                ActivityPresenter.Hide();
            }

            base.Navigated(parameter);
        }
    }

    public class NearbyPharmacyRequestModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
    }

    internal class PharmacyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
    }

    //internal class Pharmacy
    //{
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //    public string Town { get; set; }
    //    public string Region { get; set; }
    //    public string Type { get; set; }
    //    public string Telephone { get; set; }
    //    public Location Location { get; set; }
    //}

    
}
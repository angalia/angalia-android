using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Angalia.Core.ViewModels.Base;
using Angalia.Core.ViewModels.Forms;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using StreamExtensions = Angalia.Core.Extensions.StreamExtensions;

namespace Angalia.Core.ViewModels
{
    
    public class LeftDrawerViewModel : SampleListViewModelBase<NavigationItem>
    {
        #region Constructors

        public LeftDrawerViewModel()
        {
            this.Title = "Angalia";
            this.SubTitle = "A locale health watch";
            this.Icon = StreamExtensions.ToByte(this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlaceType.clinic.png"));

            this.DownloadCustomersCommand = new DelegateCommand(this.ExecuteDownloadCustomers);
            this.ShowLoginScreenCommand = new DelegateCommand(this.ExecuteShowLoginScreen);

            List<NavigationItem> items = new List<NavigationItem>();
            items.Add(new NavigationItem("Disease Surveillance", "MENU", typeof(DiseaseSurveillanceViewModel)) { Image = "searchuser.png" });
            items.Add(new NavigationItem("Nearby Pharmacies", "MENU", typeof(NearbyPharmacyViewModel)) { Image = "receivecash.png" });
            items.Add(new NavigationItem("Nearby Hospitals", "MENU", typeof(CustomMarkerViewModel)) { Image = "moneybag.png" });
            items.Add(new NavigationItem("Report Incidence", "MENU", typeof(ReportIncidenceViewModel)) { Image = "transactionlist.png" });
            items.Add(new NavigationItem("Tutorials", "MENU", this.DownloadCustomersCommand) { Image = "share.png" });
            items.Add(new NavigationItem("Settings", "", typeof(SliderViewModel)) { Image = "quantity.png" });
            items.Add(new NavigationItem("Exit", "", ShowLoginScreenCommand) { Image = "logout.png" });
            //items.Add(new NavigationItem("Simple Marker", "Markers", typeof(SimpleMarkerViewModel)));
            //items.Add(new NavigationItem("Custom Marker", "Markers", typeof(CustomMarkerViewModel)));
            //items.Add(new NavigationItem("Marker Placement", "Markers", typeof(MarkerPlacementViewModel)));
            //items.Add(new NavigationItem("Zoom Level", "Markers", typeof(ZoomLevelViewModel)));

            //items.Add(new NavigationItem("Default Route", "Directions", typeof(DefaultRouteViewModel)));
            //items.Add(new NavigationItem("Alternative Routes", "Directions", typeof(AlternativeRoutesViewModel)));
            //items.Add(new NavigationItem("Travel Mode", "Directions", typeof(TravelModeViewModel)));

            //switch (Utility.GetOperatingSystem())
            //{
            //    case OSKind.iOS:

            //        break;

            //    case OSKind.Android:
            //        items.Add(new NavigationItem("Show My Location", "UI Customization", typeof(ShowMyLocationViewModel)));
            //        break;
            //}

            this.SourceItems = items;
            this.RefreshGroupItems();
        }

        #endregion        

        public string _title;
        public string _subTitle;
        public byte[] _icon;


        #region Properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                if (_subTitle != value)
                {
                    _subTitle = value;
                    OnPropertyChanged("SubTitle");
                }
            }
        }

        public byte[] Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }
        

        public DelegateCommand DownloadCustomersCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand ShowLoginScreenCommand { get; set; }

        #endregion

        #region Methods

        public override void RefreshGroupItems()
        {
            if (this.Items != null)
                this.GroupItems = this.Items.GroupBy(o => o.Group).Select(o => new GroupItem<NavigationItem>(o)).ToList();
        }

        public void ExecuteShowLoginScreen(object parameter)
        {
            NavigationService.Close();
        }

        private void ExecuteDownloadCustomers(object parameter)
        {
            var result = this.MobileService.Browser.IsSupported();

            if (result)
                this.MobileService.Browser.Navigate("http://www.angaliagh.com");
        }

        
        #endregion
    }
}
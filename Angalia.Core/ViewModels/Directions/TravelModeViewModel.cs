using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Angalia.Core.Helpers;
using Angalia.Core.Infrastructure;
using Angalia.Core.Models;
using Angalia.Core.ModelServices;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Directions
{
    public class TravelModeViewModel : MapViewModelBase
    {
        #region Constructors

        public TravelModeViewModel()
        {
            this.Title = "Travel Mode";
            this.IncludeAlternativeRoutes = true;
            this.ChangeTravelModeCommand = new DelegateCommand(ExecuteChangeTravelMode);

            this.OriginPlacemark = this.Repository.Get(12);
            this.DestinationPlacemark = this.Repository.Get(7);

            this.Markers = new ObservableCollection<Placemark>()
            {
                this.OriginPlacemark,
                this.DestinationPlacemark
            };

            this.CameraSettings = new CameraSettings(MapRectBounds.Create(this.Markers))
            {
                EnableAnimation = true,
                Padding = 50
            };

            DirectionsMetadata directionsMetadata = new DirectionsMetadata(this.OriginPlacemark, this.DestinationPlacemark)
            {
                IncludeAlternativeRoutes = true,
                TravelMode = this.TravelMode
            };

            this.DirectionsMetadata = directionsMetadata;
        }

        #endregion

        #region Fields

        private ICommand _changeTravelModeCommand;
        private TravelMode _travelMode;
        private string[] _travelModes;

        #endregion

        #region Properties

        public ICommand ChangeTravelModeCommand
        {
            get { return _changeTravelModeCommand; }
            set
            {
                if (_changeTravelModeCommand != value)
                {
                    _changeTravelModeCommand = value;
                    OnPropertyChanged("ChangeTravelModeCommand");
                }
            }
        }

        public MedicalPlace DestinationPlacemark { get; set; }

        public MedicalPlace OriginPlacemark { get; set; }

        public IMedicalPlaceRepository Repository
        {
            get
            {
                if (Container.Current.CanResolve<IMedicalPlaceRepository>())
                    return Container.Current.Resolve<IMedicalPlaceRepository>();
                else
                    return new MedicalPlaceRepository();
            }
        }

        public TravelMode TravelMode
        {
            get { return _travelMode; }
            set
            {
                if (_travelMode != value)
                {
                    _travelMode = value;
                    OnTravelModeChanged();
                }
            }
        }

        public string[] TravelModes
        {
            get
            {
                if (_travelModes == null)
                {
                    OSKind operatingSystem = Utility.GetOperatingSystem();
                    switch (operatingSystem)
                    {
                        case OSKind.iOS:
                            _travelModes = new string[] {"Driving", "Walking"};
                            break;

                        case OSKind.Android:
                            _travelModes = new string[] {"Driving", "Walking", "Bicycling"};
                            break;
                    }
                }

                return _travelModes;
            }
        }

        #endregion

        #region Methods

        private void ExecuteChangeTravelMode(object parameter)
        {
            this.ActionPresenter.Show("Select Travel Mode", this.TravelModes, (selectedIndex) =>
            {
                if (selectedIndex >= 0)
                {
                    TravelMode travelMode = TravelMode.Driving;
                    Enum.TryParse(this.TravelModes[selectedIndex], out travelMode);
                    this.TravelMode = travelMode;
                }
            });
        }

        private void OnTravelModeChanged()
        {
            DirectionsMetadata directionsMetadata = new DirectionsMetadata(this.OriginPlacemark, this.DestinationPlacemark)
            {
                IncludeAlternativeRoutes = true,
                TravelMode = this.TravelMode
            };

            this.DirectionsMetadata = directionsMetadata;
        }

        #endregion
    }
}
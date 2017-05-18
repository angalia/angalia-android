using System.Collections.Generic;
using System.Windows.Input;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Base
{
    public abstract class MapViewModelBase : SampleViewModelBase
    {
        #region Constructors

        public MapViewModelBase()
        {
            this.CreateMarkerCommand = new DelegateCommand(ExecuteCreateMarker, CanExecuteCreateMarker);
        }

        #endregion

        #region Fields

        private CameraSettings _cameraSettings;
        private ICommand _createMarkerCommand;
        private DirectionsMetadata _directionsMetadata;
        private bool _includeAlternativeRoutes;

        private IEnumerable<Placemark> _markers;
        private IEnumerable<Route> _routes;
        private Route _selectedRoute;

        #endregion

        #region Properties

        public CameraSettings CameraSettings
        {
            get { return _cameraSettings; }
            set
            {
                if (_cameraSettings != value)
                {
                    _cameraSettings = value;
                    OnPropertyChanged("CameraSettings");
                }
            }
        }

        public ICommand CreateMarkerCommand
        {
            get { return _createMarkerCommand; }
            set
            {
                if (_createMarkerCommand != value)
                {
                    _createMarkerCommand = value;
                    OnPropertyChanged("CreateMarkerCommand");
                }
            }
        }

        public DirectionsMetadata DirectionsMetadata
        {
            get { return _directionsMetadata; }
            set
            {
                if (_directionsMetadata != value)
                {
                    _directionsMetadata = value;
                    OnPropertyChanged("DirectionsMetadata");
                }
            }
        }

        public bool IncludeAlternativeRoutes
        {
            get { return _includeAlternativeRoutes; }
            set
            {
                if (_includeAlternativeRoutes != value)
                {
                    _includeAlternativeRoutes = value;
                    OnPropertyChanged("IncludeAlternativeRoutes");
                }
            }
        }

        public IEnumerable<Placemark> Markers
        {
            get { return _markers; }
            set
            {
                if (_markers != value)
                {
                    _markers = value;
                    OnPropertyChanged("Markers");
                }
            }
        }

        public IEnumerable<Route> Routes
        {
            get { return _routes; }
            set
            {
                if (_routes != value)
                {
                    _routes = value;
                    OnPropertyChanged("Routes");
                }
            }
        }

        public Route SelectedRoute
        {
            get { return _selectedRoute; }
            set
            {
                if (_selectedRoute != value)
                {
                    _selectedRoute = value;
                    OnPropertyChanged("SelectedRoute");
                }
            }
        }

        #endregion

        #region Methods

        protected virtual bool CanExecuteCreateMarker(object parameter)
        {
            return false;
        }

        protected virtual void ExecuteCreateMarker(object parameter)
        {
        }

        #endregion
    }
}
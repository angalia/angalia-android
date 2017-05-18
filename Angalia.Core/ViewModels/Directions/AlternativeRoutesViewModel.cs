using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Angalia.Core.Infrastructure;
using Angalia.Core.Models;
using Angalia.Core.ModelServices;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Directions
{
    public class AlternativeRoutesViewModel : MapViewModelBase
    {
        #region Constructors

        public AlternativeRoutesViewModel()
        {
            this.Title = "Alternative Routes";
            this.IncludeAlternativeRoutes = true;
            this.ChangeRouteCommand = new DelegateCommand(ExecuteChangeRoute);

            this.OriginPlacemark = this.Repository.Get(8);
            this.DestinationPlacemark = this.Repository.Get(15);

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
                IncludeAlternativeRoutes = true
            };

            this.DirectionsMetadata = directionsMetadata;
        }

        #endregion

        #region Fields

        private ICommand _changeRouteCommand;

        #endregion

        #region Properties

        public ICommand ChangeRouteCommand
        {
            get { return _changeRouteCommand; }
            set
            {
                if (_changeRouteCommand != value)
                {
                    _changeRouteCommand = value;
                    OnPropertyChanged("ChangeRouteCommand");
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

        #endregion

        #region Methods

        private void ExecuteChangeRoute(object parameter)
        {
            if (this.Routes != null && this.Routes.Count() > 0)
            {
                string[] routeNames = this.Routes.Select(p => p.Summary).ToArray();

                this.ActionPresenter.Show("Select Route", routeNames, (selectedIndex) =>
                {
                    if (selectedIndex >= 0)
                        this.SelectedRoute = this.Routes.Skip(selectedIndex).FirstOrDefault();
                });
            }
            else
                this.ToastPresenter.Show("Alternative route is not available yet. Try again later.");
        }

        #endregion
    }
}
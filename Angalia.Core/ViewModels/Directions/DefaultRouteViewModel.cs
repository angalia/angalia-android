using System.Collections.ObjectModel;
using System.Linq;
using Angalia.Core.Infrastructure;
using Angalia.Core.Models;
using Angalia.Core.ModelServices;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Directions
{
    public class DefaultRouteViewModel : MapViewModelBase
    {
        #region Constructors

        public DefaultRouteViewModel()
        {
            this.Title = "Default Route";
            this.OriginPlacemark = this.Repository.Get(1);
            this.DestinationPlacemark = this.Repository.Get(11);

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

        #region Properties

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

        protected override bool CanExecuteCreateMarker(object parameter)
        {
            return true;
        }

        protected override void ExecuteCreateMarker(object parameter)
        {
            if (this.Routes != null)
            {
                int count = this.Routes.Count();
                if (count > 1)
                {
                    int currentSelectedIndex = this.Routes.IndexOf(this.SelectedRoute);
                    int newSelectedIndex = (currentSelectedIndex + 1) % count;

                    this.SelectedRoute = this.Routes.Skip(newSelectedIndex).FirstOrDefault();
                }
            }
        }

        #endregion
    }
}
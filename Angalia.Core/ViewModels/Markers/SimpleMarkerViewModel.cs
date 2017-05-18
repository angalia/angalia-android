using Angalia.Core.Infrastructure;
using Angalia.Core.ModelServices;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Markers
{
    public class SimpleMarkerViewModel : NavigationMapViewModelBase
    {
        #region Constructors

        public SimpleMarkerViewModel()
        {
            this.Title = "Simple Marker";
            this.Markers = this.Repository.GetAll();

            this.CameraSettings = new CameraSettings(MapRectBounds.Create(this.Markers))
            {
                Padding = 50
            };
        }

        #endregion

        #region Properties

        public IBeachRepository Repository
        {
            get
            {
                if (Container.Current.CanResolve<IBeachRepository>())
                    return Container.Current.Resolve<IBeachRepository>();
                else
                    return new BeachRepository();
            }
        }

        #endregion
    }
}
using System.Linq;
using Angalia.Core.Infrastructure;
using Angalia.Core.ModelServices;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.Markers
{
    public class ZoomLevelViewModel : NavigationMapViewModelBase
    {
        #region Constructors

        public ZoomLevelViewModel()
        {
            this.Title = "Zoom Level";
            this.Markers = this.Repository.GetAll().Take(1);

            this.CameraSettings = new CameraSettings(0.2);
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
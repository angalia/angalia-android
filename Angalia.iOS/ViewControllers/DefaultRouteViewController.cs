using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(DefaultRouteBindingProvider))]
    public partial class DefaultRouteViewController : UIViewController<DefaultRouteViewModel>
    {
        #region Constructors

        public DefaultRouteViewController()
            : base("DefaultRouteViewController", null)
        {
        }

        #endregion
    }
}
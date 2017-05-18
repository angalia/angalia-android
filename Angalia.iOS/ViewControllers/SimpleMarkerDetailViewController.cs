using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(CustomMarkerDetailBindingProvider))]
    public partial class SimpleMarkerDetailViewController : UIViewController<CustomMarkerDetailViewModel>
    {
        #region Constructors

        public SimpleMarkerDetailViewController()
            : base("SimpleMarkerDetailViewController", null)
        {
        }

        #endregion
    }
}
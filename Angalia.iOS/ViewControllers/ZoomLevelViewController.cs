using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(ZoomLevelBindingProvider))]
    public partial class ZoomLevelViewController : UIViewController<ZoomLevelViewModel>
    {
        #region Constructors

        public ZoomLevelViewController()
            : base("ZoomLevelViewController", null)
        {
        }

        #endregion

        #region Methods

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        #endregion
    }
}
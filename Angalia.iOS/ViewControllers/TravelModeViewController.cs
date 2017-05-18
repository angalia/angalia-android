using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;
using UIKit;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(TravelModeBindingProvider))]
    public partial class TravelModeViewController : UIViewController<TravelModeViewModel>
    {
        #region Constructors

        public TravelModeViewController()
            : base("TravelModeViewController", null)
        {
        }

        #endregion

        #region Properties

        private UIBarButtonItem ChangeTravelModeButton { get; set; }

        #endregion

        #region Methods

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }


        protected override void InitializeView()
        {
            base.InitializeView();

            this.ChangeTravelModeButton = new UIBarButtonItem();
            this.ChangeTravelModeButton.Title = "Change Travel Mode";

            this.NavigationItem.SetRightBarButtonItem(this.ChangeTravelModeButton, false);

            this.RegisterViewIdentifier("ChangeTravelMode", this.ChangeTravelModeButton);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        #endregion
    }
}
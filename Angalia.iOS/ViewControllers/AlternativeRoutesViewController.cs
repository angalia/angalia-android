using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;
using UIKit;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(AlternativeRoutesBindingProvider))]
    public partial class AlternativeRoutesViewController : UIViewController<AlternativeRoutesViewModel>
    {
        #region Constructors

        public AlternativeRoutesViewController()
            : base("AlternativeRoutesViewController", null)
        {
        }

        #endregion

        #region Properties

        private UIBarButtonItem ChangeRouteButton { get; set; }

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

            this.ChangeRouteButton = new UIBarButtonItem();
            this.ChangeRouteButton.Title = "Change Route";

            this.NavigationItem.SetRightBarButtonItem(this.ChangeRouteButton, false);

            this.RegisterViewIdentifier("ChangeRoute", this.ChangeRouteButton);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        #endregion
    }
}
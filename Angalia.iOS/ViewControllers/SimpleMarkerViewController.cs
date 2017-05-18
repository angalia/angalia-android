using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;

namespace MapSamples.iOS
{
    [ImportBinding(typeof(SimpleMarkerBindingProvider))]
    public partial class SimpleMarkerViewController : UIViewController<SimpleMarkerViewModel>
    {
        #region Constructors

        public SimpleMarkerViewController()
            : base("SimpleMarkerViewController", null)
        {
        }

        #endregion

        #region Methods

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        protected override void InitializeView()
        {
            base.InitializeView();

            this.NavigationItem.Title = "Simple Marker";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        #endregion
    }
}
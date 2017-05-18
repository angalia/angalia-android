using Foundation;
using Intersoft.Crosslight.iOS;
using MapSamples.ViewModels;
using UIKit;

namespace MapSamples.iOS
{
    [Register("DrawerNavigationController")]
    public class DrawerNavigationController : UIDrawerNavigationController<DrawerViewModel>
    {
        #region Constructors

        public DrawerNavigationController()
        {
            // Set drawer-related settings through the provided DrawerSettings property
            this.DrawerSettings.StatusBarTransitionMode = StatusBarTransitionMode.TranslucentBlur;
            this.DrawerSettings.LeftStatusBarColor = UIColor.Clear;
        }

        #endregion

        #region Methods

        protected override void OnViewCreated()
        {
            base.OnViewCreated();

            // set the title once during creation
            // the subsequent navigation will automatically synchronize the navigation title
            this.VisibleViewController.NavigationItem.Title = "Simple List";
        }

        #endregion
    }
}
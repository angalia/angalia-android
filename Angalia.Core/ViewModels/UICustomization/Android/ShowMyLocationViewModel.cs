using System;
using Angalia.Core.ViewModels.Base;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.ViewModels.UICustomization.Android
{
    public class ShowMyLocationViewModel : NavigationMapViewModelBase
    {
        #region Constructors

        public ShowMyLocationViewModel()
        {
            this.Title = "Show My Location";
        }

        #endregion

        #region Methods

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            ILocationService locationService = ServiceProvider.GetService<ILocationService>();
            if (locationService != null)
            {
                locationService.SetOwner(this);
                locationService.GetCurrentLocation(0d, (location) =>
                {
                    Exception exception = location.Error;

                    if (exception == null)
                    {
                        this.CameraSettings = new CameraSettings(new MapRectBounds(location.Location.Coordinate, 0.01))
                        {
                            EnableAnimation = true
                        };
                    }
                    else
                        this.ToastPresenter.Show(exception.Message);
                });
            }
        }

        #endregion
    }
}
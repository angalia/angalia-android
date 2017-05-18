using Angalia.Core.BindingProviders.Base;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.BindingProviders.Markers
{
    public class CustomMarkerBindingProvider : MapBindingProviderBase
    {
        #region Constructors

        public CustomMarkerBindingProvider()
        {
            this.AddBinding("Map", MapProperties.MarkerNavigationTargetProperty, new NavigationTarget(typeof(CustomMarkerDetailViewModel)), true);
        }

        #endregion
    }
}
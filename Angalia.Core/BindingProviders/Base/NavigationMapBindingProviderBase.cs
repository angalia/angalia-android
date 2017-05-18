using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.BindingProviders.Base
{
    public abstract class NavigationMapBindingProviderBase : BindingProvider
    {
        #region Constructors

        public NavigationMapBindingProviderBase()
        {
            this.AddBinding("Map", MapProperties.MarkerNavigateCommandProperty, "NavigateCommand");
        }

        #endregion
    }
}
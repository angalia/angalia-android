using Angalia.Core.BindingProviders.Base;
using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders.Directions
{
    public class TravelModeBindingProvider : MapBindingProviderBase
    {
        #region Constructors

        public TravelModeBindingProvider()
        {
            this.AddBinding("ChangeTravelMode", BindableProperties.CommandProperty, "ChangeTravelModeCommand");
        }

        #endregion
    }
}
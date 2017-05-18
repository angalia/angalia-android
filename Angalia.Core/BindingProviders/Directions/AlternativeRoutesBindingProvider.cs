using Angalia.Core.BindingProviders.Base;
using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders.Directions
{
    public class AlternativeRoutesBindingProvider : MapBindingProviderBase
    {
        #region Constructors

        public AlternativeRoutesBindingProvider()
        {
            this.AddBinding("ChangeRoute", BindableProperties.CommandProperty, "ChangeRouteCommand");
        }

        #endregion
    }
}
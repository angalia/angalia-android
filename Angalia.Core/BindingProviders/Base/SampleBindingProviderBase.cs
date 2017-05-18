using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders.Base
{
    public abstract class SampleBindingProviderBase : BindingProvider
    {
        #region Constructors

        public SampleBindingProviderBase()
        {
            this.AddBinding("ActionBar", BindableProperties.TextProperty, "Title");
        }

        #endregion
    }
}
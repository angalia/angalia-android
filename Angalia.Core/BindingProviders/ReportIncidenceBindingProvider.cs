using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders
{
    public class ReportIncidenceBindingProvider : BindingProvider
    {
        #region Constructors

        public ReportIncidenceBindingProvider()
        {
            this.AddBinding("SubmitButton", BindableProperties.CommandProperty, "SubmitCollectionCommand");
            this.AddBinding("SubmitButton", BindableProperties.HideKeyboardOnReturnProperty, true, true);
        }

        #endregion
    }
}

using Angalia.Core.BindingProviders.Base;
using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders.Markers
{
    public class CustomMarkerDetailBindingProvider : SampleBindingProviderBase
    {
        #region Constructors

        public CustomMarkerDetailBindingProvider()
        {
            this.AddBinding("TitleText", BindableProperties.TextProperty, "Marker.Name");
            this.AddBinding("AddressText", BindableProperties.TextProperty, "Marker.AddressString");
            this.AddBinding("PhoneText", BindableProperties.TextProperty, "Marker.PhoneNumber");
            this.AddBinding("BuildingImage", BindableProperties.ImageProperty, "Marker.BuildingImage");
        }

        #endregion
    }
}
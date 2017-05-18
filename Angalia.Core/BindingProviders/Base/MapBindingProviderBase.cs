using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.BindingProviders.Base
{
    public abstract class MapBindingProviderBase : SampleBindingProviderBase
    {
        #region Constructors

        public MapBindingProviderBase()
        {
            MarkerBindingDescription markerBindingDescription = new MarkerBindingDescription
            {
                DisplayMemberPath = "Name",
                DetailMemberPath = "Address",
                ImageMemberPath = "Image",
                PositionMemberPath = "Location",
                MarkerColorMemberPath = "MarkerColor",
                MarkerImageMemberPath = "MarkerImage"
            };

            this.AddBinding("Map", MapProperties.MarkersProperty, "Markers");
            this.AddBinding("Map", MapProperties.MarkerBindingDescriptionProperty, markerBindingDescription, true);
            this.AddBinding("Map", MapProperties.CreateMarkerCommandProperty, "CreateMarkerCommand");
            this.AddBinding("Map", MapProperties.CameraSettingsProperty, "CameraSettings");
            this.AddBinding("Map", MapProperties.DirectionsMetadataProperty, "DirectionsMetadata");
            this.AddBinding("Map", MapProperties.RoutesProperty, "Routes", BindingMode.TwoWay);
            this.AddBinding("Map", MapProperties.SelectedRouteProperty, "SelectedRoute", BindingMode.TwoWay);
            this.AddBinding("Map", MapProperties.IncludeAlternativeRoutesProperty, "IncludeAlternativeRoutes");
        }

        #endregion
    }
}
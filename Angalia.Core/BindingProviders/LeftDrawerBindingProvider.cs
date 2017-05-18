using Intersoft.Crosslight;

namespace Angalia.Core.BindingProviders
{
    public class LeftDrawerBindingProvider : BindingProvider
    {
        #region Constructors

        public LeftDrawerBindingProvider()
        {
            var itemBinding = new ItemBindingDescription
            {
                DisplayMemberPath = "Title",
                NavigateMemberPath = "Target",
                DetailMemberPath = "Detail",
                ImageMemberPath = "Image",
                ImagePlaceholder = "item_placeholder.png"
            };

            // Bind the View's ItemsSource property with ID/Outlet set to TableView
            // with ViewModel property Items.
            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);

            this.AddBinding("nav_header_title", BindableProperties.TextProperty, "Title");
            this.AddBinding("nav_header_sub_title", BindableProperties.TextProperty, "SubTitle");
            this.AddBinding("nav_header_icon", BindableProperties.ImageProperty, "Icon");
        }

        #endregion
    }
}
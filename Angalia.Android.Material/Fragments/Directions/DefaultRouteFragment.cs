using Angalia.Core.BindingProviders.Directions;
using Angalia.Core.ViewModels.Directions;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Directions
{
    [ImportBinding(typeof(DefaultRouteBindingProvider))]
    public class DefaultRouteFragment : MapFragment<DefaultRouteViewModel>
    {
        #region Constructors

        public DefaultRouteFragment()
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}
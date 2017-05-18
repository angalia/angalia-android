using Angalia.Core.BindingProviders.Directions;
using Angalia.Core.ViewModels.Directions;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Directions
{
    [ImportBinding(typeof(AlternativeRoutesBindingProvider))]
    public class AlternativeRoutesFragment : MapFragment<AlternativeRoutesViewModel>
    {
        #region Constructors

        public AlternativeRoutesFragment()
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("ChangeRoute", "Change Route", Resource.Drawable.ic_changeroute));
            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}
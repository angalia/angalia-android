using Angalia.Core.BindingProviders.Directions;
using Angalia.Core.ViewModels.Directions;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Directions
{
    [ImportBinding(typeof(TravelModeBindingProvider))]
    public class TravelModeFragment : MapFragment<TravelModeViewModel>
    {
        #region Constructors

        public TravelModeFragment()
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("ChangeTravelMode", "Change Travel Mode", Resource.Drawable.ic_changetravelmode));
            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}
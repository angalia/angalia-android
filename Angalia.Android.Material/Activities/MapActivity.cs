using Android.App;
using MapSamples.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.UI.Android;

namespace MapSamples.Android
{
    [Activity(Label = "Crosslight App")]
    [ImportBinding(typeof(SimpleBindingProvider))]
    public class MapActivity : MapActivity<SimpleMapViewModel>
    {
        #region Constructors

        public MapActivity()
        {
        }

        #endregion
    }
}
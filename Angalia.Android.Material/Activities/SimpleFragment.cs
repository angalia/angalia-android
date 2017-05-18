using Android.App;
using MapSamples.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;

namespace MapSamples.Android
{
    [Fragment(Label = "Crosslight App")]
    [ImportBinding(typeof(SimpleBindingProvider))]
    public class SimpleFragment : Fragment<SimpleViewModel>
    {
        #region Constructors

        public SimpleFragment()
            : base(Resource.Layout.MainLayout)
        {
        }

        #endregion
    }
}
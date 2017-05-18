using System;
using Android.Runtime;
using Angalia.Core.BindingProviders.Markers;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Markers
{
    [ImportBinding(typeof(SimpleMarkerBindingProvider))]
    public class SimpleMarkerFragment : MapFragment<SimpleMarkerViewModel>
    {
        #region Constructors

        public SimpleMarkerFragment()
            : base()
        {
        }

        protected SimpleMarkerFragment(SimpleMarkerViewModel viewModel)
            : base(viewModel)
        {
        }

        protected SimpleMarkerFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion

        #region Properties

        protected override int InfoWindowLayoutId
        {
            get { return 0; }
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
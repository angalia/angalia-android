using System;
using Android.Runtime;
using Angalia.Core.BindingProviders.Markers;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Markers
{
    [ImportBinding(typeof(CustomMarkerBindingProvider))]
    public class CustomMarkerFragment : MapFragment<CustomMarkerViewModel>
    {
        #region Constructors

        public CustomMarkerFragment()
        {
        }

        protected CustomMarkerFragment(CustomMarkerViewModel viewModel)
            : base(viewModel)
        {
        }

        protected CustomMarkerFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            //this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}
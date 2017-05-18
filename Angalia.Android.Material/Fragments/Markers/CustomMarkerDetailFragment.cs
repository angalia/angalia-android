using System;
using Android.Runtime;
using Angalia.Core.BindingProviders.Markers;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;

namespace Angalia.Android.Fragments.Markers
{
    [ImportBinding(typeof(CustomMarkerDetailBindingProvider))]
    public class CustomMarkerDetailFragment : Intersoft.Crosslight.Android.v7.Fragment<CustomMarkerDetailViewModel>
    {
        #region Constructors

        public CustomMarkerDetailFragment()
            : base()
        {
        }

        protected CustomMarkerDetailFragment(CustomMarkerDetailViewModel viewModel)
            : base(viewModel)
        {
        }

        protected CustomMarkerDetailFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.custom_marker_detail_layout; }
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
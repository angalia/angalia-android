using System;
using Android.Runtime;
using Angalia.Core.BindingProviders.Markers;
using Angalia.Core.ViewModels.Markers;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.Markers
{
    [ImportBinding(typeof(ZoomLevelBindingProvider))]
    public class ZoomLevelFragment : MapFragment<ZoomLevelViewModel>
    {
        #region Constructors

        public ZoomLevelFragment()
        {
        }

        protected ZoomLevelFragment(ZoomLevelViewModel viewModel)
            : base(viewModel)
        {
        }

        protected ZoomLevelFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
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
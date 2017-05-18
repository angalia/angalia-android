using System;
using Android.Runtime;
using Angalia.Core.BindingProviders.UICustomization;
using Angalia.Core.ViewModels.UICustomization.Android;
using Intersoft.Crosslight;
using Intersoft.Crosslight.UI.Android.v7;

namespace Angalia.Android.Fragments.UICustomization
{
    [ImportBinding(typeof(ShowMyLocationBindingProvider))]
    public class ShowMyLocationFragment : MapFragment<ShowMyLocationViewModel>
    {
        #region Constructors

        public ShowMyLocationFragment()
        {
        }

        protected ShowMyLocationFragment(ShowMyLocationViewModel viewModel)
            : base(viewModel)
        {
        }

        protected ShowMyLocationFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion

        #region Properties

        protected override bool IsMyLocationEnabled
        {
            get { return true; }
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
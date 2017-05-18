using System;
using Android.Runtime;
using Angalia.Core.BindingProviders;
using Angalia.Core.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;

namespace Angalia.Android.Fragments
{
    [ImportBinding(typeof(LeftDrawerBindingProvider))]
    public class LeftDrawerFragment : RecyclerViewFragment<LeftDrawerViewModel>
    {
        #region Constructors

        public LeftDrawerFragment()
        {
        }

        protected LeftDrawerFragment(LeftDrawerViewModel viewModel)
            : base(viewModel)
        {
        }

        protected LeftDrawerFragment(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion

        #region Properties

        protected override int HeaderLayoutId
        {
            get { return Resource.Layout.custom_header; }
        }
        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.CellStyle = CellStyle.NavigationDrawer;
            this.InteractionMode = ListViewInteraction.Navigation;
        }

        #endregion
    }
}
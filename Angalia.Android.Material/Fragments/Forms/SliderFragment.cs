using System;
using Android.Runtime;
using Angalia.Core.ViewModels.Forms;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;

namespace Angalia.Android.Fragments.Forms
{
    public class SliderFragment : FormFragment<SliderViewModel>
    {
        #region Constructors

        public SliderFragment()
        {
        }

        public SliderFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("SaveButton", CommandItemType.Done));
        }

        #endregion
    }
}
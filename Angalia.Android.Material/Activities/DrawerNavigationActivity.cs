using System;
using Android.App;
using Android.Runtime;
using Angalia.Core.ViewModels;
using Intersoft.Crosslight.Android.v7;

namespace Angalia.Android.Activities
{
    [Activity()]
    public class DrawerNavigationActivity : DrawerActivity<DrawerViewModel>
    {
        #region Constructors

        public DrawerNavigationActivity()
            : base()
        {
        }

        protected DrawerNavigationActivity(IntPtr intPtr, JniHandleOwnership handleOwnership)
            : base(intPtr, handleOwnership)
        {
        }

        #endregion
    }
}
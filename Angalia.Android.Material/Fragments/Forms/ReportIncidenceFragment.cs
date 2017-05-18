#region Template Instruction

/* To use this template you need to replace the following placeholder:
 *  - TViewModel, type of the view model associated with this fragment
 *  
 * To learn more how to use this template, see http://developer.intersoftpt.com/display/crosslight/Using+Crosslight+Item+Templates
 */

#endregion

using System;
using Android.Runtime;
using Angalia.Core.ViewModels.Forms;
using Intersoft.Crosslight.Android.v7;

namespace Angalia.Android.Fragments.Forms
{
    public class ReportIncidenceFragment : FormFragment<ReportIncidenceViewModel>
    {
        #region Constructors

        public ReportIncidenceFragment()
        {
        }

        public ReportIncidenceFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            //To learn more how to configure this template, 
            //see http://developer.intersoftsolutions.com/display/crosslight/Using+Material+Form+Fragment
            base.Initialize();

            //this.AddBarItem(new BarItem("SaveButton", CommandItemType.Done));
        }

        #endregion
    }
}
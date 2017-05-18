using Angalia.Core.ViewModels.Forms;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class DrawerViewModel : DrawerViewModelBase
    {
        #region Constructors

        public DrawerViewModel()
        {
            this.LeftViewModel = new LeftDrawerViewModel();
            this.CenterViewModel = new ReportIncidenceViewModel();
        }

        #endregion
    }
}
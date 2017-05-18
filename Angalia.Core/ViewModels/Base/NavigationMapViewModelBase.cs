using System.Windows.Input;
using Intersoft.Crosslight.Input;

namespace Angalia.Core.ViewModels.Base
{
    public abstract class NavigationMapViewModelBase : MapViewModelBase
    {
        #region Constructors

        public NavigationMapViewModelBase()
        {
            this.NavigateCommand = new DelegateCommand(ExecuteNavigate, CanExecuteNavigate);
        }

        #endregion

        #region Properties

        public ICommand NavigateCommand { get; set; }

        #endregion

        #region Methods

        protected virtual bool CanExecuteNavigate(object parameter)
        {
            return false;
        }

        protected virtual void ExecuteNavigate(object parameter)
        {
        }

        #endregion
    }
}
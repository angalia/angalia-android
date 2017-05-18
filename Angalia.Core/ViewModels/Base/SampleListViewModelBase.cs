using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels.Base
{
    public abstract class SampleListViewModelBase<T> : ListViewModelBase<T> where T : NavigationItem
    {
        #region Constructors

        public SampleListViewModelBase()
        {
            this.FooterText = "Powered by Teksol®";
        }

        #endregion

        #region Fields

        private string _footerText;

        #endregion

        #region Properties

        public string FooterText
        {
            get { return _footerText; }
            set
            {
                if (_footerText != value)
                {
                    _footerText = value;
                    OnPropertyChanged("FooterText");
                }
            }
        }

        #endregion
    }
}
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels.Base
{
    public abstract class SampleViewModelBase : ViewModelBase
    {
        #region Constructors

        public SampleViewModelBase()
        {
            this.FooterText = "Powered by Crosslight®";
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
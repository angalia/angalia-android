using Intersoft.Crosslight;

namespace Angalia.Core.Models
{
    [Serializable]
    public partial class Disease : ModelBase
    {
        #region Fields

        private string _accountName;

        #endregion

        #region Properties

        public string Name
        {
            get { return _accountName; }
            set
            {
                if (_accountName != value)
                {
                    _accountName = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        #endregion
    }
}

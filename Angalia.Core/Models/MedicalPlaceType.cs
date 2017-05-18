using Intersoft.Crosslight;

namespace Angalia.Core.Models
{
    [Serializable]
    public partial class MedicalPlaceType : Base.ModelBase
    {
        #region Fields

        private byte[] _icon;

        private int _id;
        private string _name;

        #endregion

        #region Properties

        public byte[] Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        #endregion
    }
}
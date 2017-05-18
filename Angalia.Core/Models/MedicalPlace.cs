using Intersoft.Crosslight;
using Intersoft.Crosslight.Mobile;

namespace Angalia.Core.Models
{
    [Serializable]
    public partial class MedicalPlace : MarkerPlacemark
    {
        #region Constructors

        public MedicalPlace(Location location, PlacemarkAddress address, string placemarkName)
            : base(location, address, placemarkName)
        {
        }

        #endregion

        #region Fields

        private byte[] _buildingImage;

        private int _id;
        private string _phoneNumber;
        private MedicalPlaceType _type;
        private int _typeId;

        #endregion

        #region Properties

        public byte[] BuildingImage
        {
            get { return _buildingImage; }
            set
            {
                if (_buildingImage != value)
                {
                    _buildingImage = value;
                    OnPropertyChanged("BuildingImage");
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

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public MedicalPlaceType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                    OnTypeChanged();
                }
            }
        }

        public int TypeId
        {
            get { return _typeId; }
            private set
            {
                if (_typeId != value)
                {
                    _typeId = value;
                    OnPropertyChanged("TypeId");
                }
            }
        }

        #endregion

        #region Methods

        private void OnTypeChanged()
        {
            if (this.Type != null)
            {
                this.TypeId = this.Type.Id;
                this.MarkerImage = this.Type.Icon;
            }
            else
            {
                this.TypeId = 0;
                this.MarkerImage = null;
            }
        }

        #endregion
    }
}
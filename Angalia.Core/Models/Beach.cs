using Intersoft.Crosslight;
using Intersoft.Crosslight.Mobile;

namespace Angalia.Core.Models
{
    [Serializable]
    public partial class Beach : MarkerPlacemark
    {
        #region Constructors

        public Beach(Location location, PlacemarkAddress address, string placemarkName)
            : base(location, address, placemarkName)
        {
        }

        #endregion

        #region Fields

        private int _id;

        #endregion

        #region Properties

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

        #endregion
    }
}
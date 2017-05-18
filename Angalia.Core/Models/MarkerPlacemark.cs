using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.UI.Core;

namespace Angalia.Core.Models
{
    public class MarkerPlacemark : Placemark
    {
        #region Constructors

        public MarkerPlacemark(Location location, PlacemarkAddress address, string placemarkName)
            : base(location, address, placemarkName)
        {
        }

        #endregion

        #region Fields

        private object _image;

        private MarkerColors _markerColor;
        private object _markerImage;

        #endregion

        #region Properties

        public string AddressString
        {
            get { return this.Address.ToString(); }
        }

        public object Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        public MarkerColors MarkerColor
        {
            get { return _markerColor; }
            set
            {
                if (_markerColor != value)
                {
                    _markerColor = value;
                    OnPropertyChanged("MarkerColor");
                }
            }
        }

        public object MarkerImage
        {
            get { return _markerImage; }
            set
            {
                if (_markerImage != value)
                {
                    _markerImage = value;
                    OnPropertyChanged("MarkerImage");
                }
            }
        }

        #endregion
    }
}
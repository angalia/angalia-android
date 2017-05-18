using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Angalia.Core.Extensions;
using Angalia.Core.Infrastructure;
using Angalia.Core.Models;
using Intersoft.Crosslight.Mobile;

namespace Angalia.Core.ModelServices
{
    /// <summary>
    ///     Represents a XML data repository that provides read-only data access.
    /// </summary>
    public class MedicalPlaceRepository : IMedicalPlaceRepository
    {
        #region Fields

        private IList<MedicalPlace> _places;

        #endregion

        #region Properties

        private IMedicalPlaceTypeRepository MedicalPlaceTypeRepository
        {
            get
            {
                if (Container.Current.CanResolve<IMedicalPlaceTypeRepository>())
                    return Container.Current.Resolve<IMedicalPlaceTypeRepository>();
                else
                    return new MedicalPlaceTypeRepository(); // design time support
            }
        }

        #endregion

        #region Methods

        private MedicalPlace CreatePlace(XElement x)
        {
            Location location = this.ParseLocation(x.Element("Location"));
            PlacemarkAddress placemarkAddress = new PlacemarkAddress(x.Element("StreetName").Value, x.Element("State").Value, x.Element("PostalCode").Value, x.Element("City").Value, x.Element("Country").Value);
            string placemarkName = x.Element("Name").Value;

            MedicalPlace place = new MedicalPlace(location, placemarkAddress, placemarkName)
            {
                Id = int.Parse(x.Element("Id").Value),
                PhoneNumber = x.Element("PhoneNumber").Value,
                Image = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlace." + x.Element("Logo").Value).ToByte(),
                BuildingImage = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlace." + x.Element("BuildingImage").Value).ToByte(),
                Type = this.MedicalPlaceTypeRepository.Get(int.Parse(x.Element("TypeId").Value))
            };

            return place;
        }

        public MedicalPlace Get(int id)
        {
            return this.GetAll().FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<MedicalPlace> GetAll()
        {
            if (_places == null)
            {
                XDocument doc = XDocument.Load(this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Data.MedicalPlaces.xml"));

                var placesQuery = from x in doc.Descendants("MedicalPlace") select CreatePlace(x);

                _places = new ObservableCollection<MedicalPlace>(placesQuery);
            }

            return _places;
        }

        private bool ParseBoolean(XElement element)
        {
            if (element == null || string.IsNullOrEmpty(element.Value))
                return false;

            return bool.Parse(element.Value);
        }

        private Location ParseLocation(XElement element)
        {
            Location location = new Location();

            if (element != null && !string.IsNullOrEmpty(element.Value))
            {
                string[] parts = element.Value.Split(',');

                double latitude = 0;
                double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out latitude);

                double longitude = 0;
                double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out longitude);

                location.Coordinate = new LocationCoordinate(latitude, longitude);
            }

            return location;
        }

        #endregion
    }
}
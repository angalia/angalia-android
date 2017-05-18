using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Angalia.Core.Models;
using Intersoft.Crosslight.Mobile;

namespace Angalia.Core.ModelServices
{
    /// <summary>
    ///     Represents a XML data repository that provides read-only data access.
    /// </summary>
    public class BeachRepository : IBeachRepository
    {
        #region Fields

        private IList<Beach> _beaches;

        #endregion

        #region Methods

        private Beach CreateBeach(XElement x)
        {
            Location location = this.ParseLocation(x.Element("Location"));
            PlacemarkAddress placemarkAddress = new PlacemarkAddress(x.Element("StreetName").Value, x.Element("State").Value, x.Element("PostalCode").Value, x.Element("City").Value, x.Element("Country").Value);
            string placemarkName = x.Element("Name").Value;

            Beach beach = new Beach(location, placemarkAddress, placemarkName)
            {
                Id = int.Parse(x.Element("Id").Value)
            };

            return beach;
        }

        public Beach Get(int id)
        {
            return this.GetAll().FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Beach> GetAll()
        {
            if (_beaches == null)
            {
                XDocument doc = XDocument.Load(this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Data.Beaches.xml"));

                var beachesQuery = from x in doc.Descendants("Beach") select CreateBeach(x);

                _beaches = new ObservableCollection<Beach>(beachesQuery);
            }

            return _beaches;
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
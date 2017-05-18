using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Angalia.Core.Extensions;
using Angalia.Core.Models;

namespace Angalia.Core.ModelServices
{
    /// <summary>
    ///     Represents a XML data repository that provides read-only data access.
    /// </summary>
    public class MedicalPlaceTypeRepository : IMedicalPlaceTypeRepository
    {
        #region Fields

        private IList<MedicalPlaceType> _placeTypes;

        #endregion

        #region Methods

        private MedicalPlaceType CreateMedicalPlaceType(XElement x)
        {
            MedicalPlaceType medicalPlaceType = new MedicalPlaceType()
            {
                Id = int.Parse(x.Element("Id").Value),
                Name = x.Element("Name").Value,
                Icon = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Images.MedicalPlaceType." + x.Element("Icon").Value).ToByte()
            };

            return medicalPlaceType;
        }

        public MedicalPlaceType Get(int id)
        {
            return this.GetAll().FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<MedicalPlaceType> GetAll()
        {
            if (_placeTypes == null)
            {
                XDocument doc = XDocument.Load(this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MapSamples.Core.Assets.Data.MedicalPlaceTypes.xml"));

                var placeTypesQuery = from x in doc.Descendants("MedicalPlaceType") select CreateMedicalPlaceType(x);

                _placeTypes = new ObservableCollection<MedicalPlaceType>(placeTypesQuery);
            }

            return _placeTypes;
        }

        #endregion
    }
}
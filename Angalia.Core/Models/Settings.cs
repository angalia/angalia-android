using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;

namespace Angalia.Core.Models
{
    [Serializable]
    public partial class Settings : ModelBase
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int HospitalNearbyRadius { get; set; }
        public int PharmacyNearbyRadius { get; set; }


        public override void Validate()
        {
            this.ClearAllErrors();
        }
    }
}

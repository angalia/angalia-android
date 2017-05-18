using Intersoft.Crosslight;

namespace Angalia.Core.Models
{
    [Serializable]
    public class Pharmacy : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public string Telephone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override void Validate()
        {
            this.ClearAllErrors();
        }
    }
}

using System.Collections.Generic;

namespace Angalia.Core.Models
{
    public class PharmacyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
    }
}

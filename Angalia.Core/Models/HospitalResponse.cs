using System.Collections.Generic;

namespace Angalia.Core.Models
{
    public class HospitalResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Hospital> Hospitals { get; set; }
    }
}

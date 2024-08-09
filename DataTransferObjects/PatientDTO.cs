using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public int? PatientAge { get; set; }

    }
}

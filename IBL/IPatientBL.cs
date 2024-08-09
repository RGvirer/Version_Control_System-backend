using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IPatientBL
    {
        public List<PatientDTO> GetAll();
        public bool Get(PatientDTO item);
        public bool AddNew(PatientDTO item);
        public bool Delete(PatientDTO item);
        public bool Update(PatientDTO item);
    }
}

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
        public PatientDTO Get(int id);
        public bool AddNew(PatientDTO item);
        public bool Delete(int id);
        public bool Update(PatientDTO item);
    }
}

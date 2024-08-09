using DataTransferObjects;

namespace IDAL
{
    public interface IPatientDAL
    {
        public bool AddNew(PatientDTO entity);
        public PatientDTO Get(int id);
        public List<PatientDTO> GetAll();
        public bool Update(PatientDTO entity);
        public bool Delete(PatientDTO entity);
    }
}

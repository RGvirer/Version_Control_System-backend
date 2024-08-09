using DataTransferObjects;

namespace IDAL
{
    public interface IDepartmentDAL
    {
        public bool AddNew(DepartmentDTO entity);
        public DepartmentDTO Get(int id);
        public List<DepartmentDTO> GetAll();
        public bool Update(DepartmentDTO entity);
        public bool Delete(DepartmentDTO entity);
    }
}

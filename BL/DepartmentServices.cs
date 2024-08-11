using DataTransferObjects;
using IBL;
using IDAL;

namespace BL
{
    public class DepartmentServices : IBL.IDepartmentBL
    {
        private readonly IDepartmentDAL departmentDal;
        public DepartmentServices(IDepartmentDAL _departmentDAL)
        {
            departmentDal = _departmentDAL;
        }

        public bool AddNew(DepartmentDTO department)
        {
            try
            {
                return departmentDal.AddNew(department);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                DepartmentDTO departmentDto = departmentDal.GetAll().Find(department => department.DepartmentId == id) ?? new DepartmentDTO();
                return departmentDal.Delete(departmentDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DepartmentDTO Get(int id)
        {
            try
            {
                DepartmentDTO departmentDto = departmentDal.GetAll().Find(department => department.DepartmentId == id) ?? new DepartmentDTO();
                return departmentDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<DepartmentDTO> GetAll()
        {
            try
            {
                return departmentDal.GetAll();
            }
            catch (Exception)
            {
                return new List<DepartmentDTO>();
            }
        }


        public bool Update(DepartmentDTO department)
        {
            try
            {
                return departmentDal.Update(department);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

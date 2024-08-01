using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BL
{
    public class DepartmentServices : IBL.IObjectBL
    {
        private readonly IObjectDAL iDepartmentDal;

        public DepartmentServices(IObjectDAL departmentDal)
        {
            iDepartmentDal = departmentDal;
        }

        public bool AddNew(object item)
        {
            try
            {
                return iDepartmentDal.AddNew(item);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object item)
        {
            try
            {
                return iDepartmentDal.Delete(item);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<object> GetAll(Func<object, bool>? condition = null)
        {
            try
            {
                return iDepartmentDal.GetAll(condition);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            try
            {
                return iDepartmentDal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

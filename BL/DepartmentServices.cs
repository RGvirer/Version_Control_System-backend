using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BL
{
    internal class DepartmentServices : IBL.IObjectBL
    {
        private readonly IObjectDAL departmentDal;

        public DepartmentServices(IObjectDAL departmentDal)
        {
            this.departmentDal = departmentDal;
        }

        public bool AddNew(object item)
        {
            try
            {
                return departmentDal.AddNew(item);
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
                return departmentDal.Delete(item);
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
                return departmentDal.GetAll(condition);
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
                return departmentDal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

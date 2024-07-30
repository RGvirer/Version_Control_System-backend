using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class DepartmentServices : IBL.IObjectBL
    {
        public bool AddNew(object item)
        {
            try
            {
                DAL.DepartmentDAL dal = new();
                return dal.AddNew(item);
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
                DAL.DepartmentDAL dal = new();
                return dal.Delete(item);
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
                DAL.DepartmentDAL dal = new();
                return dal.GetAll(condition);
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
                DAL.DepartmentDAL dal = new();
                return dal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

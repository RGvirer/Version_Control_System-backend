using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BL
{
    public class UserServices : IBL.IObjectBL
    {
        private readonly IObjectDAL userDal;

        public UserServices(IObjectDAL userDal)
        {
            this.userDal = userDal;
        }

        public bool AddNew(object item)
        {
            try
            {
                return userDal.AddNew(item);
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
                return userDal.Delete(item);
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
                return userDal.GetAll(condition);
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
                return userDal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

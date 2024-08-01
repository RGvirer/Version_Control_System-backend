using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class UserServices : IBL.IUserBL
    {
        private readonly IObjectDAL userDal;
        private readonly DbContext dbContext;
        public UserServices(IObjectDAL _userDal, DbContext _dbContext)
        {
            userDal = _userDal;
            dbContext = _dbContext;
        }

        public bool AddNew(object user)
        {
            try
            {
                userDal.AddNew(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object user)
        {
            try
            {
                userDal.Delete(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<object> GetAll()
        {
            try
            {
                return userDal.GetAll();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public List<object> GetAll(Func<object, bool>? condition = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(object user)
        {
            try
            {
                userDal.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

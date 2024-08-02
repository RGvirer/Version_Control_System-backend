using System;
using System.Collections.Generic;
using System.Linq;
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
                return userDal.AddNew(user);
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

        public bool Get(object item)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll()
        {
            try
            {
                return userDal.GetAll();
            }
            catch (Exception)
            {
                return new List<object>();
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
                return userDal.Update(user);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

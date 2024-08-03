using System;
using System.Collections.Generic;
using System.Linq;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class UserServices : IBL.IUserBL
    {
        private readonly IUserDAL userDal;
        private readonly IAppDbContext dbContext;
        public UserServices(IUserDAL _userDal, IAppDbContext _dbContext)
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
                return userDal.Delete(user);
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

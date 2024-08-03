using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PatientDAL : IDAL.IObjectDAL
    {
        private readonly RivkiGvirerContext dbContext;
        public PatientDAL(RivkiGvirerContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddNew(object patient)
        {
            try
            {
                dbContext.Patients.Add((Patient)patient);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object patient)
        {
            try
            {
                dbContext.Patients.Remove((Patient)patient);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public object Get(int id)
        {
            try
            {
                return dbContext.Patients.Find(id);
            }
            catch (Exception)
            {
                return null;
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
                return dbContext.Patients.Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }


        public bool Update(object patient)
        {
            try
            {
                dbContext.Patients.Update((Patient)patient);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

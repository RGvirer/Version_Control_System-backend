using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DAL
{
    public class PatientDAL : IDAL.IObjectDAL
    {
        public bool AddNew(object item)
        {
            if (item is Patient patient)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Patients.Add(patient);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool Delete(object item)
        {
            if (item is Patient patient)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Patients.Remove(patient);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public List<object> GetAll(Func<object, bool>? condition = null)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                var patients = ctx.Patients.ToList();
                return condition == null ? patients.Cast<object>().ToList() : patients.Where(condition).Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            if (item is Patient patient)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Patients.Update(patient);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}

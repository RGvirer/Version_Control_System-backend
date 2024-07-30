using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BL
{
    public class PatientsServices : IBL.IObjectBL
    {
        private readonly IObjectDAL patientDal;

        public PatientsServices(IObjectDAL patientDal)
        {
            this.patientDal = patientDal;
        }

        public bool AddNew(object item)
        {
            try
            {
                return patientDal.AddNew(item);
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
                return patientDal.Delete(item);
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
                return patientDal.GetAll(condition);
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
                return patientDal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

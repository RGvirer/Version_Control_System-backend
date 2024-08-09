using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IObjectDAL
    {
        public bool AddNew(object entity);
        public object Get(int id);
        public List<object> GetAll();
        public bool Update(object entity);
        public bool Delete(int id);
    }
}

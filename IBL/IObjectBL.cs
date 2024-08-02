using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IObjectBL
    {
        public List<object> GetAll(Func<object, bool>? condition = null);
        public bool Get(object item);
        public bool AddNew(object item);
        public bool Delete(object item);
        public bool Update(object item);
    }
}
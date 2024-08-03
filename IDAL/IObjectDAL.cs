using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IObjectDAL
    {
        bool AddNew(object item);
        bool Get(object item);
        List<object> GetAll();
        bool Delete(object item);
        bool Update(object item);
    }
}

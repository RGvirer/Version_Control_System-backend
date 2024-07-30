using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IObjectBL
    {
        List<object> GetAll(Func<object, bool>? condition = null);
        bool AddNew(object item);
        bool Delete(object item);
        bool Update(object item);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace IBL
{
    public interface IObjectBL
    {
        //int AddNew(UserDTO entity);
        //List<UserDTO> GetAll();
        public List<object> GetAll();
        public bool Get(object item);
        public bool AddNew(object item);
        public bool Delete(object item);
        public bool Update(object item);
    }
}
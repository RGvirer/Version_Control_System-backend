using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IDepartmentBL
    {
        public List<DepartmentDTO> GetAll();
        public DepartmentDTO Get(int id);
        public bool AddNew(DepartmentDTO item);
        public bool Delete(int id);
        public bool Update(DepartmentDTO item);
    }
}

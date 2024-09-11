using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IRepositoryBL
    {
        public List<RepositoryDTO> GetAll();
        public RepositoryDTO Get(int id);
        public bool AddNew(RepositoryDTO item);
        public bool Delete(int id);
        public bool Update(RepositoryDTO item);
    }
}

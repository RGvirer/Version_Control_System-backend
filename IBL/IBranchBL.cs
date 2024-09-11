using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IBranchBL
    {
        public List<BranchDTO> GetAll();
        public BranchDTO Get(int id);
        public bool AddNew(BranchDTO item);
        public bool Delete(int id);
        public bool Update(BranchDTO item);
    }
}

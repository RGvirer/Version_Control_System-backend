using DataTransferObjects;

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

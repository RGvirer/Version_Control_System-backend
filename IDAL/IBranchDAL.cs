using DataTransferObjects;

namespace IDAL
{
    public interface IBranchDAL
    {
        public bool AddNew(BranchDTO entity);
        public BranchDTO Get(int id);
        public List<BranchDTO> GetAll();
        public bool Update(BranchDTO entity);
        public bool Delete(BranchDTO entity);
    }
}

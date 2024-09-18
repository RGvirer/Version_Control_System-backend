using DataTransferObjects;

namespace IDAL
{
    public interface IMergeDAL
    {
        public bool AddNew(MergeDTO entity);
        public MergeDTO Get(int id);
        public List<MergeDTO> GetAll();
        public bool Update(MergeDTO entity);
        public bool Delete(MergeDTO entity);
    }
}

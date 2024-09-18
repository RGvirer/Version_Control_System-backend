using DataTransferObjects;

namespace IBL
{
    public interface IMergeBL
    {
        public List<MergeDTO> GetAll();
        public MergeDTO Get(int id);
        public bool AddNew(MergeDTO item);
        public bool Delete(int id);
        public bool Update(MergeDTO item);
    }
}

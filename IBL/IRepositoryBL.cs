using DataTransferObjects;

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

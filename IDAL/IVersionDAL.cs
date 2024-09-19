using DataTransferObjects;

namespace IDAL
{
    public interface IVersionDAL
    {
        public bool AddNew(VersionDTO entity);
        public VersionDTO Get(int id);
        public List<VersionDTO> GetAll();
        public bool Update(VersionDTO entity);
        public bool Delete(VersionDTO entity);
    }
}

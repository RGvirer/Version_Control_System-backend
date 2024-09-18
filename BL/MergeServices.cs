using DataTransferObjects;
using IDAL;

namespace BL
{
    public class MergeServices : IBL.IMergeBL
    {
        private readonly IMergeDAL mergeDal;
        public MergeServices(IMergeDAL _mergeDal)
        {
            mergeDal = _mergeDal;
        }

        public bool AddNew(MergeDTO merge)
        {
            try
            {
                return mergeDal.AddNew(merge);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                MergeDTO mergeDto = mergeDal.GetAll().Find(merge => merge.MergeId == id) ?? new MergeDTO();
                return mergeDal.Delete(mergeDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MergeDTO Get(int id)
        {
            try
            {
                MergeDTO mergeDto = mergeDal.GetAll().Find(merge => merge.MergeId == id) ?? new MergeDTO();
                return mergeDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<MergeDTO> GetAll()
        {
            try
            {
                return mergeDal.GetAll();
            }
            catch (Exception)
            {
                return new List<MergeDTO>();
            }
        }


        public bool Update(MergeDTO merge)
        {
            try
            {
                return mergeDal.Update(merge);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

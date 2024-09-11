using System;
using System.Collections.Generic;
using System.Linq;
using DataTransferObjects;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class BranchServices : IBL.IBranchBL
    {
        private readonly IBranchDAL branchDal;
        public BranchServices(IBranchDAL _branchDAL)
        {
            branchDal = _branchDAL;
        }

        public bool AddNew(BranchDTO branch)
        {
            try
            {
                return branchDal.AddNew(branch);
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
                BranchDTO branchDto = branchDal.GetAll().Find(branch => branch.BranchId == id) ?? new BranchDTO();
                return IBranchDAL.Delete(branchDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BranchDTO Get(int id)
        {
            try
            {
                BranchDTO branchDto = branchDal.GetAll().Find(branch => branch.BranchId == id) ?? new BranchDTO();
                return branchDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<BranchDTO> GetAll()
        {
            try
            {
                return branchDal.GetAll();
            }
            catch (Exception)
            {
                return new List<BranchDTO>();
            }
        }


        public bool Update(BranchDTO branch)
        {
            try
            {
                return branchDal.Update(branch);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

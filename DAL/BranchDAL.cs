﻿using AutoMapper;
using DAL.Models;
using DataTransferObjects;

namespace DAL
{
    public class BranchDal : IDAL.IBranchDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public BranchDal(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(BranchDTO branch)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BranchDTO, Branch>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Branch>(branch);

                dbContext.Branches.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(BranchDTO branchDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BranchDTO, Branch>();
                });

                var localMapper = config.CreateMapper();
                var branchEntity = localMapper.Map<Branch>(branchDto);

                var branchToDelete = dbContext.Branches.Find(branchEntity.BranchId);
                if (branchToDelete != null)
                {
                    dbContext.Branches.Remove(branchToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                return false; // המשתמש לא נמצא
            }
            catch (Exception ex)
            {
                // טיפול בלוג או פעולות אחרות כדי להבין את הבעיה
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<BranchDTO> GetAll()
        {
            try
            {
                var branches = dbContext.Branches.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Branch, BranchDTO>()
                    .ForMember(dest => dest.RepositoryId, opt => opt.MapFrom(src => src.RepositoryId))
                        .ReverseMap();
                });


                var localMapper = config.CreateMapper();
                return branches.Select(branch => localMapper.Map<BranchDTO>(branch)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public BranchDTO Get(int id)
        {
            try
            {
                var branch = dbContext.Branches.Find(id);
                if (branch == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Branch, BranchDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<BranchDTO>(branch);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(BranchDTO branch)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BranchDTO, Branch>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Branch>(branch);

                dbContext.Branches.Update(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
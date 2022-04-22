using AutoMapper;
using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Repository.Interfaces;
using JahzeenApi.Service.Interfaces;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Services
{
    public class ExperienceService : IExperienceService
    {

        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IExperienceRepository _repositoryExperienceRepository;
        private IMapper _mapper;

        public ExperienceService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public Experience Add(Experience entity)
        {

            Experience PostedExperience = _repositoryUnitOfWork.Experience.Value.Add(entity);
            return PostedExperience;
        }

        public ExperienceAddDTO AddEntity(ExperienceAddDTO entity)
        {
            Experience Experience = _mapper.Map<Experience>(entity);
            Experience PostedExperience = _repositoryUnitOfWork.Experience.Value.Add(Experience);
            return entity;
        }

        public IEnumerable<Experience> AddRange(IEnumerable<Experience> entities)
        {
            throw new NotImplementedException();
        }

        public Experience Get(long Id)
        {
            throw new NotImplementedException();
        }
        public ExperienceDTO GetById(int Id)
        {
            Experience Experience = _repositoryUnitOfWork.Experience.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            ExperienceDTO ExperienceDTO = _mapper.Map<ExperienceDTO>(Experience);
            return ExperienceDTO;
        }

        public IEnumerable<Experience> GetAll()
        {
            throw new NotImplementedException();
        }

        public Experience Remove(Experience entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            bool isRemoved = _repositoryUnitOfWork.Experience.Value.Remove(Id);
            return isRemoved;
        }

        public IEnumerable<Experience> RemoveRange(IEnumerable<Experience> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Experience> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Experience Update(Experience entity)
        {
            Experience PostedExperience = _repositoryUnitOfWork.Experience.Value.Add(entity);
            return PostedExperience;
        }

        public ExperienceAddDTO UpdateEntity(ExperienceAddDTO entity)
        {

            Experience Experience = _mapper.Map<Experience>(entity);
            Experience UpdatedExperience = _repositoryUnitOfWork.Experience.Value.Update(Experience);
            return entity;
        }

        public IEnumerable<Experience> UpdateRange(IEnumerable<Experience> entities)
        {
            throw new NotImplementedException();
        }

        public BaseListResponse<ExperienceDTO> GetList(BaseSearch baseSearch)
        {
            BaseListResponse<Experience> Experience = _repositoryUnitOfWork.Experience.Value.GetList(x =>
                                                                                             (string.IsNullOrEmpty(baseSearch.Name))
                                                                                             , baseSearch.PageSize
                                                                                             , baseSearch.PageNumber
                                                                                             , x => x.ExperienceType
                                                                                             , x => x.JobTitle
                                                                                             , x => x.Employer
                                                                                             , x => x.From
                                                                                             , x => x.To
                                                                                             , x => x.ApplicationUserId
                                                                                             , x => x.CreatedBy
                                                                                             , x => x.ModifiedBy);
            List<ExperienceDTO> ExperienceDTOs = _mapper.Map<List<ExperienceDTO>>(Experience.Entities);

            return new BaseListResponse<ExperienceDTO>
            {
                Entities = ExperienceDTOs,
                TotalCount = Experience.TotalCount
            };
        }

    }
}

using AutoMapper;
using Domains.DTO;
using Domains.SearchModels;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Service.Interfaces;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Service.Services
{
    public class UserSkillService : IUserSkillService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public UserSkillService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public UserSkill Add(UserSkill entity)
        {
            UserSkill PostedUserSkill = _repositoryUnitOfWork.UserSkill.Value.Add(entity);
            return PostedUserSkill;
        }

        public UserSkillAddDTO AddEntity(UserSkillAddDTO entity)
        {
            UserSkill UserSkill = _mapper.Map<UserSkill>(entity);
            UserSkill PostedUserSkill = _repositoryUnitOfWork.UserSkill.Value.Add(UserSkill);
            return entity;
        }

        public IEnumerable<UserSkill> AddRange(IEnumerable<UserSkill> entities)
        {
            throw new NotImplementedException();
        }

        public UserSkill Get(long Id)
        {
            throw new NotImplementedException();
        }
        public UserSkillDTO GetById(int Id)
        {
            UserSkill UserSkill = _repositoryUnitOfWork.UserSkill.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            UserSkillDTO UserSkillDTO = _mapper.Map<UserSkillDTO>(UserSkill);
            return UserSkillDTO;
        }
        public IEnumerable<UserSkillDTO> GetByUserId(int UserId)
        {
            IEnumerable<UserSkillDTO> UserSkills = _repositoryUnitOfWork.UserSkill.Value.GetByUserId(UserId);
            return UserSkills;
        }

        public IEnumerable<UserSkill> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserSkill Remove(UserSkill entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            bool isRemoved = _repositoryUnitOfWork.UserSkill.Value.Remove(Id);
            return isRemoved;
        }

        public IEnumerable<UserSkill> RemoveRange(IEnumerable<UserSkill> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSkill> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public UserSkill Update(UserSkill entity)
        {

            UserSkill PostedUserSkill = _repositoryUnitOfWork.UserSkill.Value.Add(entity);
            return PostedUserSkill;
        }

        public UserSkillAddDTO UpdateEntity(UserSkillAddDTO entity)
        {
            UserSkill UserSkill = _mapper.Map<UserSkill>(entity);
            UserSkill UpdatedUserSkill = _repositoryUnitOfWork.UserSkill.Value.Update(UserSkill);
            return entity;
        }

        public IEnumerable<UserSkill> UpdateRange(IEnumerable<UserSkill> entities)
        {
            throw new NotImplementedException();
        }

        public BaseListResponse<UserSkillDTO> GetList(BaseSearch baseSearch)
        {
            BaseListResponse<UserSkill> UserSkill = _repositoryUnitOfWork.UserSkill.Value.GetList(x =>
                                                                                             (string.IsNullOrEmpty(baseSearch.Name)
                                                                                             || x.Skill.Name.Contains(baseSearch.Name))
                                                                                             , baseSearch.PageSize
                                                                                             , baseSearch.PageNumber
                                                                                             , x => x.CreatedBy
                                                                                             , x => x.Skill
                                                                                             , x => x.ModifiedBy);
            List<UserSkillDTO> skillDTOs = _mapper.Map<List<UserSkillDTO>>(UserSkill.Entities);

            return new BaseListResponse<UserSkillDTO>
            {
                Entities = skillDTOs,
                TotalCount = UserSkill.TotalCount
            };
        }
    }
}

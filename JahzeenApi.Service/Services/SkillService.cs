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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Services
{
    public class SkillService : ISkillService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public SkillService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public Skill Add(Skill entity)
        {
            if(_repositoryUnitOfWork.Skill.Value.Any(x=>x.Name == entity.Name))
            {
                throw new ValidationException("Skill name already exists !!!");
            }

            Skill PostedSkill = _repositoryUnitOfWork.Skill.Value.Add(entity);
            return PostedSkill;
        }

        public SkillAddDTO AddEntity(SkillAddDTO entity)
        {
            if (_repositoryUnitOfWork.Skill.Value.Any(x => x.Name == entity.Name))
            {
                throw new ValidationException("Skill name already exists !!!");
            }
            Skill Skill = _mapper.Map<Skill>(entity);
            Skill PostedSkill = _repositoryUnitOfWork.Skill.Value.Add(Skill);
            return entity;
        }

        public IEnumerable<Skill> AddRange(IEnumerable<Skill> entities)
        {
            throw new NotImplementedException();
        }

        public Skill Get(long Id)
        {
            throw new NotImplementedException();
        }
        public SkillDTO GetById(int Id)
        {
            Skill Skill = _repositoryUnitOfWork.Skill.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            SkillDTO SkillDTO = _mapper.Map<SkillDTO>(Skill);
            return SkillDTO;
        }

        public IEnumerable<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public Skill Remove(Skill entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            bool isRemoved = _repositoryUnitOfWork.Skill.Value.Remove(Id);
            return isRemoved;
        }

        public IEnumerable<Skill> RemoveRange(IEnumerable<Skill> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Skill Update(Skill entity)
        {
            if (_repositoryUnitOfWork.Skill.Value.Any(x =>x.Id != entity.Id && x.Name == entity.Name))
            {
                throw new ValidationException("Skill name already exists !!!");
            }

            Skill PostedSkill = _repositoryUnitOfWork.Skill.Value.Add(entity);
            return PostedSkill;
        }

        public SkillAddDTO UpdateEntity(SkillAddDTO entity)
        {
            if (_repositoryUnitOfWork.Skill.Value.Any(x => x.Id != entity.Id && x.Name == entity.Name))
            {
                throw new ValidationException("Skill name already exists !!!");
            }

            Skill Skill = _mapper.Map<Skill>(entity);
            Skill UpdatedSkill = _repositoryUnitOfWork.Skill.Value.Update(Skill);
            return entity;
        }

        public IEnumerable<Skill> UpdateRange(IEnumerable<Skill> entities)
        {
            throw new NotImplementedException();
        }

        public BaseListResponse<SkillDTO> GetList(BaseSearch baseSearch)
        {
            BaseListResponse<Skill> Skill = _repositoryUnitOfWork.Skill.Value.GetList(x =>
                                                                                             (string.IsNullOrEmpty(baseSearch.Name)
                                                                                             || x.Name.Contains(baseSearch.Name))
                                                                                             , baseSearch.PageSize
                                                                                             , baseSearch.PageNumber
                                                                                             , x => x.CreatedBy
                                                                                             , x => x.ModifiedBy);
            List<SkillDTO> skillDTOs = _mapper.Map<List<SkillDTO>>(Skill.Entities);

            return new BaseListResponse<SkillDTO>
            {
                Entities = skillDTOs,
                TotalCount = Skill.TotalCount
            };
        }
        public List<SkillDTO> GetAllEntities()
        {
            IEnumerable<Skill> Skills = _repositoryUnitOfWork.Skill.Value.GetAll(x => x.CreatedBy, x => x.ModifiedBy);
            List<SkillDTO> skillDTOs = _mapper.Map<List<SkillDTO>>(Skills);
            return skillDTOs;              
        }
    }
}

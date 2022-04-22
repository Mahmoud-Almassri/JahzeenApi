using AutoMapper;
using Domain;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Repository.Interfaces;
using Repository.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JahzeenApi.Repository.Repositories
{
    public class UserSkillRepository : Repository<UserSkill>, IUserSkillRepository
    {
        private JahzeenContext _context;
        private IMapper _mapper;

        public UserSkillRepository(JahzeenContext context,
            IMapper mapper
            ) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UserSkillDTO> GetByUserId(int UserId)
        {
            List<UserSkill> UserSkills = _context.UserSkill.Where(x => x.UserId == UserId).Include(x => x.User).Include(x => x.Skill).ToList();
            IEnumerable<UserSkillDTO> UserSkillsDTO = _mapper.Map<IEnumerable<UserSkillDTO>>(UserSkills);
            return UserSkillsDTO;
        }
    }
}

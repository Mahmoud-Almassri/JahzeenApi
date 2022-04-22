using AutoMapper;
using Domain;
using JahzeenApi.Repository.Interfaces;
using JahzeenApi.Repository.Repositories;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using Repository.Repositories.Common;
using System;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private JahzeenContext _context;
        private IMapper _mapper;
       
        public Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        public Lazy<IUserRoleRepository> UserRoles { get; set; }
        public Lazy<IRoleRepository>  RoleRepository { get; set; }
        public Lazy<IContactUsRepository>  ContactUs { get; set; }
        public Lazy<IAppSettingsRepository>  AppSettings { get; set; }
        public Lazy<ISkillRepository>  Skill { get; set; }
        public Lazy<IUserSkillRepository>  UserSkill { get; set; }
        public Lazy<IExperienceRepository> Experience { get; set; }
        public Lazy<ICompanyRepository> Company { get; set; }
        public Lazy<IUsersRepository> Users { get; set; }
        public Lazy<IEmployeeAttachmentsRepository> EmployeeAttachments { get; set; }
        public Lazy<IComapnyBrachesRepository> CompanyBranches { get; set; }
        public Lazy<IApprovalRepository> Approval { get; set; }
        public Lazy<IActionRepository> Action { get; set; }

        public RepositoryUnitOfWork(JahzeenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            ApplicationExceptions = new Lazy<IApplicationExceptionsRepository>(() => new ApplicationExceptionsRepository(_context));
            UserRoles = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(_context,_mapper));
            RoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(_context));
            ContactUs = new Lazy<IContactUsRepository>(() => new ContactUsRepository(_context));
            AppSettings = new Lazy<IAppSettingsRepository>(() => new AppSettingsRepository(_context));
            Skill = new Lazy<ISkillRepository>(() => new SkillRepository(_context));
            UserSkill = new Lazy<IUserSkillRepository>(() => new UserSkillRepository(_context,_mapper));
            Experience = new Lazy<IExperienceRepository>(() => new ExperienceRepository(_context));
            Company = new Lazy<ICompanyRepository>(() => new CompanyRepository(_context));
            Users = new Lazy<IUsersRepository>(() => new UsersRepository(_context , mapper));
            EmployeeAttachments = new Lazy<IEmployeeAttachmentsRepository>(() => new EmployeeAttachmentsRepository(_context ));
            CompanyBranches = new Lazy<IComapnyBrachesRepository>(() => new CompanyBranchesRepository(_context));
            Approval = new Lazy<IApprovalRepository>(() => new ApprovalRepository(_context)); ;
            Action = new Lazy<IActionRepository>(() => new ActionRepository(_context)); ;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

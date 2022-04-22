using JahzeenApi.Repository.Interfaces;
using JahzeenApi.Repository.Repositories;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using System;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        Lazy<IUserRoleRepository> UserRoles { get; set; }
        Lazy<IRoleRepository> RoleRepository { get; set; }
        Lazy<IContactUsRepository> ContactUs { get; set; }
        Lazy<IAppSettingsRepository> AppSettings { get; set; }
        Lazy<ISkillRepository> Skill { get; set; }
        Lazy<IUserSkillRepository> UserSkill { get; set; }
        Lazy<IExperienceRepository> Experience { get; set; }
        Lazy<ICompanyRepository> Company { get; set; }
        Lazy<IUsersRepository> Users { get; set; }
        Lazy<IEmployeeAttachmentsRepository> EmployeeAttachments { get; set; }
        Lazy<IComapnyBrachesRepository> CompanyBranches { get; set; }
        Lazy<IApprovalRepository> Approval { get; set; }
        Lazy<IActionRepository> Action { get; set; }
        
    }
}

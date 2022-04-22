using JahzeenApi.Service.Interfaces;
using Service.Interfaces;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UnitOfWork
{
    public interface IServiceUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        Lazy<IEmployerAuthService> EmployerAuth { get; set; }
        Lazy<IEmployeeAuthService> EmployeeAuth { get; set; }
        Lazy<IEmployeeService> Employee { get; set; }
        Lazy<IEmployerService> Employer { get; set; }
        Lazy<IUserService> User { get; set; }
        Lazy<IWebUserService> WebUser { get; set; }
        Lazy<IContactUsService> ContactUs { get; set; }
        Lazy<IAppSettingsService> AppSettings { get; set; }
        Lazy<ISkillService> Skill { get; set; }
        Lazy<IExperienceService> Experience { get; set; }
        Lazy<IApprovalService> Approval { get; set; }
        Lazy<IEmployeeAttachmentsService> EmployeeAttachments { get; set; }
        Lazy<IAdminAuthService> AdminAuth { get; set; }
        Lazy<IUserSkillService> UserSkill { get; set; }
    }
}

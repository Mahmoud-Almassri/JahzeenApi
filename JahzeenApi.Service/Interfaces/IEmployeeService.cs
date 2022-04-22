using JahzeenApi.Domain.Models;
using System.Threading.Tasks;
using JahzeenApi.Domain.DTO;
using Domains.DTO;
using Google.Apis.Auth;
using JahzeenApi.Domain.DTO.AddDTO;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeHomeDTO GetHomeDashboard();
        EmployeeResponseDTO GetProfile();
        Task<EmployeeUpdateProfile> UpdateProfile(EmployeeUpdateProfile profile);
        Task<EmployeeAttachmentsAddUpdateDTO> UploadProfileAttachment(EmployeeAttachmentsAddUpdateDTO profile);
        EmployeeResponseDTO GetProfileById(int userId);
        Task<bool> DeleteEmployeeSkill(int Id);
        Task<bool> DeleteEmployeeExperience(int Id);
        Task<EmployeeAttachments> GetEmployeeAttachments();


    }
}

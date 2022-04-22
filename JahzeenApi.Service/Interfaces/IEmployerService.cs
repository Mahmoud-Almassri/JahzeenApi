using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployerService
    {
        EmployerHomeDTO GetHomeDashboard();
        EmployerResponseDTO GetProfile();
        Task<EmployerUpdateProfile> UpdateProfile(EmployerUpdateProfile profile);
        Task<EmployerAttachmentsAddUpdateDTO> UploadProfileAttachment(EmployerAttachmentsAddUpdateDTO profile);
        EmployerResponseDTO GetProfileById(int Id);
        //CompanyBranches Add(EmployerUpdateProfile profile);

    }
}

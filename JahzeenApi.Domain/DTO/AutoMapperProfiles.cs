using AutoMapper;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;

namespace JahzeenApi.Domain.DTO
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, UserProfileRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserProfileResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, RegisteredUserResponseDTO>().ReverseMap();
            CreateMap<Roles, RoleDTO>().ReverseMap();
            CreateMap<UserRoles, UserRolesDTO>().ReverseMap();
            CreateMap<AppSettings, AppSettingsAddUpdateDTO>().ReverseMap();
            CreateMap<Skill, SkillAddDTO>().ReverseMap();
            CreateMap<Skill, SkillDTO>()
                .ForMember(dest => dest.CreatedByName,
                           opt => opt.MapFrom(src => src.CreatedBy.FullName))
                .ForMember(dest => dest.ModifiedByName,
                           opt => opt.MapFrom(src => src.ModifiedBy.FullName)).ReverseMap();
            CreateMap<UserSkill, UserSkillDTO>()
                .ForMember(dest => dest.SkillName,
                           opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom(src => src.User.FullName)).ReverseMap();
            CreateMap<CompanyBranches, CompanyBrachesDTO>().ReverseMap();
            CreateMap<Experience, ExperienceDTO>().ReverseMap();
            CreateMap<UserSkill, UserSkillAddDTO>().ReverseMap();
            CreateMap<UserSkill, UserSkillDTO>()
                .ForMember(dest => dest.CreatedByName,
                           opt => opt.MapFrom(src => src.CreatedBy.PhoneNumber))
                .ForMember(dest => dest.ModifiedByName,
                           opt => opt.MapFrom(src => src.ModifiedBy.PhoneNumber))
                .ForMember(dest => dest.SkillName,
                           opt => opt.MapFrom(src => src.Skill.Name)).ReverseMap();


            CreateMap<Approvals, EmployeeApprovalDTO>()
                .ForMember(dest => dest.AccountId,
                           opt => opt.MapFrom(src => src.Account.Id))
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.Account.FullName))
                .ForMember(dest => dest.ApprovalStatus,
                           opt => opt.MapFrom(src => src.Account.ApprovalStatus))
                .ForMember(dest => dest.Gender,
                           opt => opt.MapFrom(src => src.Account.Gender))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Account.Email))
                .ForMember(dest => dest.YearOfBirth,
                           opt => opt.MapFrom(src => src.Account.YearOfBirth))
                .ForMember(dest => dest.PhoneNumber,
                           opt => opt.MapFrom(src => src.Account.PhoneNumber))
                .ForMember(dest => dest.Latitude,
                           opt => opt.MapFrom(src => src.Account.Latitude))
                .ForMember(dest => dest.Longitude,
                           opt => opt.MapFrom(src => src.Account.Longitude))
                .ForMember(dest => dest.ModifiedDate,
                           opt => opt.MapFrom(src => src.Account.ModificationDate))
                .ReverseMap();

            CreateMap<Approvals, EmployerApprovalDTO>()
                .ForMember(dest => dest.AccountId,
                           opt => opt.MapFrom(src => src.Account.Id))
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.Account.FullName))
                .ForMember(dest => dest.ApprovalStatus,
                           opt => opt.MapFrom(src => src.Account.ApprovalStatus))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Account.Email))
                .ForMember(dest => dest.Latitude,
                           opt => opt.MapFrom(src => src.Account.Latitude))
                .ForMember(dest => dest.Longitude,
                           opt => opt.MapFrom(src => src.Account.Longitude))
                .ForMember(dest => dest.ModifiedDate,
                           opt => opt.MapFrom(src => src.Account.ModificationDate))
                .ReverseMap();
            
            
            CreateMap<Company, EmployerApprovalDTO>()
                .ForMember(dest => dest.AccountId,
                           opt => opt.MapFrom(src => src.Approval.AccountId))
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.Approval.Account.FullName))
                .ForMember(dest => dest.ApprovalStatus,
                           opt => opt.MapFrom(src => src.Approval.Account.ApprovalStatus))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Approval.Account.Email))
                .ForMember(dest => dest.Latitude,
                           opt => opt.MapFrom(src => src.Approval.Account.Latitude))
                .ForMember(dest => dest.Longitude,
                           opt => opt.MapFrom(src => src.Approval.Account.Longitude))
                .ForMember(dest =>dest.ApprovalId ,
                            opt => opt.MapFrom(src => src.Approval.Id)).ReverseMap();

            CreateMap<EmployeeAttachments, EmployeeAttachmentDTO>().ReverseMap();

        }
    }
}

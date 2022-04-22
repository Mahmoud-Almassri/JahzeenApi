using AutoMapper;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Enums;
using JahzeenApi.Domain.Models;
using JahzeenApi.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IMapper _mapper;
        private FileUploader fileUploaderHelper;
        public EmployerService(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IRepositoryUnitOfWork repositoryUnitOfWork,
            LoggedInUserService loggedInUserService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironmen
            )
        {
            _loggedInUserService = loggedInUserService;
            _userManager = userManager;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            fileUploaderHelper = new FileUploader(webHostEnvironmen/*, serviceUnitOfWork*/);

        }

        public EmployerHomeDTO GetHomeDashboard()
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            int profileCpmletenessCount = 0;
            if (!string.IsNullOrEmpty(user.FullName))
            {
                profileCpmletenessCount++;
            }
            if (user.YearOfBirth.HasValue)
            {
                profileCpmletenessCount++;
            }
            if (user.Gender.HasValue)
            {
                profileCpmletenessCount++;
            }
            if (!string.IsNullOrEmpty(user.LastEducationLevel))
            {
                profileCpmletenessCount++;
            }
            if (!string.IsNullOrEmpty(user.Latitude))
            {
                profileCpmletenessCount++;
            }
            if (!string.IsNullOrEmpty(user.Longitude))
            {
                profileCpmletenessCount++;
            }
            //var userExperience=_repositoryUnitOfWork.Experience.value
            //var userExperience=_repositoryUnitOfWork.Attachments.value
            IEnumerable<UserSkillDTO> userSkills = _repositoryUnitOfWork.UserSkill.Value.GetByUserId(userId);
            if (userSkills.Count() > 0)
            {
                profileCpmletenessCount++;
            }
            int percantage = (profileCpmletenessCount / 14) * 100;
            EmployerHomeDTO response = new EmployerHomeDTO()
            {
                UserId = user.Id,
                Name = user.FullName,
                IsActive = user.IsActive,
                ProfileCompleteness = percantage.ToString() + " %",
                //ProfileImgUrl = user.ProfileImgUrl
            };

            return response;

        }

        public async Task<EmployerUpdateProfile> UpdateProfile(EmployerUpdateProfile profile)
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            Company company = _repositoryUnitOfWork.Company.Value.FirstOrDefault(x => x.UserId == userId);
            Approvals approvals = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.AccountId == userId);



            if (company != null)
            {
                #region Set Company Object
                company.CompanyName = profile.CompanyName;
                company.ContactPersonName = profile.ContactPersonName;
                company.ContactPersonTitle = profile.ContactPersonTitle;
                company.MobileNumber = profile.MobileNumber;
                company.CompanySize = profile.CompanySize;
                company.IndustryOption = profile.IndustryOption;
                #endregion
                
                //if (profile.CompanyBranches.Count > 0)
                //{
                    List<CompanyBranches> companieBranches = _repositoryUnitOfWork.CompanyBranches.Value.Find(x => x.CompanyId == company.Id).ToList();

                    if(companieBranches.Count > 0)
                    {
                        _repositoryUnitOfWork.CompanyBranches.Value.RemoveRange(companieBranches);
                        List<CompanyBranches> branches = _mapper.Map<List<CompanyBranches>>(profile.CompanyBranches);
                        foreach(CompanyBranches branch in branches)
                        {
                            branch.Id = 0;
                            branch.CompanyId = company.Id;
                            _repositoryUnitOfWork.CompanyBranches.Value.Add(branch);
                        }
                       
                    }
                    else
                    {
                        IEnumerable<CompanyBranches> branches = _mapper.Map<IEnumerable<CompanyBranches>>(profile.CompanyBranches);
                        foreach (CompanyBranches companieBranch in branches)
                        {
                            companieBranch.Id = 0;
                            companieBranch.CompanyId = company.Id;   
                        }
                        _repositoryUnitOfWork.CompanyBranches.Value.AddRange(branches);

                    }
                   
                //}
                _repositoryUnitOfWork.Company.Value.Update(company);
            }
            else
            {
                Company newCompany = new Company();

                #region Set Company Object
                newCompany.UserId = userId;
                newCompany.ApprovalId = approvals.Id;
                newCompany.CompanyName = profile.CompanyName;
                newCompany.ContactPersonName = profile.ContactPersonName;
                newCompany.ContactPersonTitle = profile.ContactPersonTitle;
                newCompany.MobileNumber = profile.MobileNumber;
                newCompany.CompanySize = profile.CompanySize;
                newCompany.IndustryOption = profile.IndustryOption;
                #endregion

                #region Attachment
                CompanyAttachmentDTO attachmentDTO = new CompanyAttachmentDTO
                {
                    CompnayLogo = profile.CompanyLogoPath,
                    CommercialRegister = profile.CommercialRegisterPath,
                    OtherAttachment = profile.OtherAttachmentPath
                };
                attachmentDTO = fileUploaderHelper.UploadCompanyAttachment(attachmentDTO);

                newCompany.CompanyLogoPath = attachmentDTO.CompanyLogoPath;
                newCompany.CommercialRegisterPath = attachmentDTO.CommercialRegisterPath;
                newCompany.OtherAttachmentPath = attachmentDTO.OtherAttachmentPath;
                #endregion

                if (profile.CompanyBranches.Count > 0)
                {
                    List<CompanyBranches> branches = _mapper.Map<List<CompanyBranches>>(profile.CompanyBranches);
                    newCompany.CompanyBranches = branches;
                }
                _repositoryUnitOfWork.Company.Value.Add(newCompany);
            }
            user.ApprovalStatus = (int)ApprovalStatus.submittedForApproval;
            await _userManager.UpdateAsync(user);

            return profile;
        }

        public async Task<EmployerAttachmentsAddUpdateDTO> UploadProfileAttachment(EmployerAttachmentsAddUpdateDTO attachment)
        {
            
                int userId = _loggedInUserService.GetUserId();
                ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                Company employerCompany = _repositoryUnitOfWork.Company.Value.FirstOrDefault(x => x.UserId == userId);
            
            #region  AddEmployerAttachments
                if (user.ApprovalStatus == (int)ApprovalStatus.New)
                {
                    Company attach = fileUploaderHelper.UploadCompanyAttachments(attachment);
                    if (attach.CompanyLogoPath != null) employerCompany.CompanyLogoPath = attach.CompanyLogoPath;
                    if (attach.CommercialRegisterPath != null) employerCompany.CommercialRegisterPath = attach.CommercialRegisterPath; ;
                    if (attach.OtherAttachmentPath != null) employerCompany.OtherAttachmentPath = attach.OtherAttachmentPath;
                    _repositoryUnitOfWork.Company.Value.Update(employerCompany);
                }
                else if (user.ApprovalStatus == (int)ApprovalStatus.Decline || user.ApprovalStatus == (int)ApprovalStatus.submittedForApproval)
                {
                    #region Attachment Update

                    if (employerCompany != null)
                    {
                    #region Add The New Attachments And Updadate
                    Company attach = fileUploaderHelper.UploadCompanyAttachments(attachment);
                    if (attach.CompanyLogoPath != null)
                    {
                        if (employerCompany.CompanyLogoPath != null)
                        {
                            fileUploaderHelper.DeleteFile(employerCompany.CompanyLogoPath);
                        }
                        employerCompany.CompanyLogoPath = attach.CompanyLogoPath;
                    }
                    if (attach.CommercialRegisterPath != null)
                    {
                        if (employerCompany.CommercialRegisterPath != null)
                        {
                            fileUploaderHelper.DeleteFile(employerCompany.CommercialRegisterPath);
                        }
                        employerCompany.CommercialRegisterPath = attach.CommercialRegisterPath;
                    }
                    if (attach.OtherAttachmentPath != null)
                    {
                        if (employerCompany.OtherAttachmentPath != null)
                        {
                            fileUploaderHelper.DeleteFile(employerCompany.OtherAttachmentPath);
                        }
                        employerCompany.OtherAttachmentPath = attach.OtherAttachmentPath;
                    }
                    _repositoryUnitOfWork.Company.Value.Update(employerCompany);
                    #endregion
                }
                    else
                    {
                    #region Add Files Add File Name
                    Company attach = fileUploaderHelper.UploadCompanyAttachments(attachment);
                    attach.UserId = user.Id;
                    _repositoryUnitOfWork.Company.Value.Update(employerCompany);
                    #endregion
                }

                    #endregion
                }

                #endregion

                return attachment;
            }

        public EmployerResponseDTO GetProfile()
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            Company company = _repositoryUnitOfWork.Company.Value.FirstOrDefault(x => x.UserId == userId , x=>x.CompanyBranches);

            EmployerResponseDTO employer = new EmployerResponseDTO();

            employer.Id = userId;
            employer.Longitude = user.Longitude;
            employer.Latitude = user.Latitude;
            employer.FullName = user.FullName;
            employer.Email = user.Email;
            
            if(company != null)
            {
                employer.CompanyName = company.CompanyName;
                employer.CompanySize = company.CompanySize;
                employer.ContactPersonName = company.ContactPersonName;
                employer.ContactPersonTitle = company.ContactPersonTitle;
                employer.ContactPersonMobileNumber = company.MobileNumber;
                employer.IndustryOption = company.IndustryOption;
                employer.CompanyLogoPath = company.CompanyLogoPath;
                employer.CommercialRegisterPath = company.CommercialRegisterPath;
                employer.OtherAttachmentPath = company.OtherAttachmentPath;

                List<CompanyBrachesDTO> companyBrachesDTOs = _mapper.Map<List<CompanyBrachesDTO>>(company.CompanyBranches);
                employer.CompanyBranches = companyBrachesDTOs;
            }

            return employer;

        }

        public EmployerResponseDTO GetProfileById(int userId)
        {
            //int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            Company company = _repositoryUnitOfWork.Company.Value.FirstOrDefault(x => x.UserId == userId, x => x.CompanyBranches);

            EmployerResponseDTO employer = new EmployerResponseDTO();

            employer.Id = userId;
            employer.Longitude = user.Longitude;
            employer.Latitude = user.Latitude;
            employer.FullName = user.FullName;
            employer.Email = user.Email;

            if (company != null)
            {
                employer.CompanyName = company.CompanyName;
                employer.CompanySize = company.CompanySize;
                employer.ContactPersonName = company.ContactPersonName;
                employer.ContactPersonTitle = company.ContactPersonTitle;
                employer.ContactPersonMobileNumber = company.MobileNumber;
                employer.IndustryOption = company.IndustryOption;
                employer.CompanyLogoPath = company.CompanyLogoPath;
                employer.CommercialRegisterPath = company.CommercialRegisterPath;
                employer.OtherAttachmentPath = company.OtherAttachmentPath;

                List<CompanyBrachesDTO> companyBrachesDTOs = _mapper.Map<List<CompanyBrachesDTO>>(company.CompanyBranches);
                employer.CompanyBranches = companyBrachesDTOs;
            }

            return employer;

        }
        }



        //public CompanyBranches Add(EmployerUpdateProfile Profile)
        //{
        //    CompanyBranches companyBranches = _mapper.Map<CompanyBranches>(Profile.CompanyBranches);
        //    CompanyBranches PostedExperience = _repositoryUnitOfWork.CompanyBranches.Value.Add(companyBranches);
        //    return PostedExperience;
        //}

    }


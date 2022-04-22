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
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        private readonly IMapper _mapper;
        private FileUploader fileUploaderHelper;

        public EmployeeService(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IRepositoryUnitOfWork repositoryUnitOfWork,
            LoggedInUserService loggedInUserService,
            /* IServiceUnitOfWork serviceUnitOfWork, */
            IWebHostEnvironment webHostEnvironmen,
            IMapper mapper)
        {
            _loggedInUserService = loggedInUserService;
            _userManager = userManager;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            fileUploaderHelper = new FileUploader(webHostEnvironmen/*, serviceUnitOfWork*/);
        }

        public EmployeeHomeDTO GetHomeDashboard()
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
            //var percantage = (profileCpmletenessCount / 15) * 100;
            var value = ((double)profileCpmletenessCount / 15) * 100;
            int percentage = Convert.ToInt32(Math.Round(value, 0));

            EmployeeHomeDTO response = new EmployeeHomeDTO()
            {
                UserId = user.Id,
                Name = user.FullName,
                IsActive = user.IsActive,
                ProfileCompleteness = percentage.ToString() + " %",
                RecommendedJobs = 1
            };

            return response;

        }
        public async Task<EmployeeUpdateProfile> UpdateProfile(EmployeeUpdateProfile profile)
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            #region update user object
            user.FullName = profile.FirstName + " " + profile.LastName;
            user.YearOfBirth = profile.YearOfBirth;
            user.LastEducationLevel = profile.LastEducationLevel;
            user.Latitude = profile.Latitude;
            user.Longitude = profile.Longitude;
            user.Gender = profile.Gender;
            user.NoPrevExperience = profile.NoPrevExperience;
            #endregion

            //if (user.ApprovalStatus == (int)ApprovalStatus.New)
            //{
            //    #region Experiences Add
            //    if (profile.Experiences.Count > 0)
            //    {
            //        IEnumerable<Experience> experiences = _mapper.Map<IEnumerable<Experience>>(profile.Experiences);
            //        _repositoryUnitOfWork.Experience.Value.AddRange(experiences);
            //    }
            //    #endregion

            //    #region Skills Add
            //    if (profile.Skills.Count > 0)
            //    {
            //        IEnumerable<UserSkill> skills = _mapper.Map<IEnumerable<UserSkill>>(profile.Skills);
            //        _repositoryUnitOfWork.UserSkill.Value.AddRange(skills);
            //    }
            //    #endregion

            //    #region  ATtachment Add
            //    if (profile.Attachments != null)
            //    {
            //        fileUploaderHelper.UploadEmployeeAttachments(profile.Attachments);
            //    }
            //    #endregion
            //}
            //else if (user.ApprovalStatus == (int)ApprovalStatus.Decline)
            //{
            //    #region Attachment Update
            //    if (profile.Attachments != null)
            //    {
            //        EmployeeAttachments attachments = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);

            //        if (attachments != null)
            //        {
            //            #region Delete Files And Files Name
            //            fileUploaderHelper.DeleteFile(attachments.LastEducationCertificatePath);
            //            fileUploaderHelper.DeleteFile(attachments.PersonalPicturePath);
            //            fileUploaderHelper.DeleteFile(attachments.NoCriminalRecordPath);
            //            fileUploaderHelper.DeleteFile(attachments.PersonalId);
            //            #endregion

            //            #region Add The New Attachments And Upda
            //            EmployeeAttachments attach = fileUploaderHelper.UploadEmployeeAttachments(profile.Attachments);
            //            attachments.PersonalPicturePath = attach.PersonalPicturePath;
            //            attachments.NoCriminalRecordPath = attach.NoCriminalRecordPath;
            //            attachments.LastEducationCertificatePath = attach.LastEducationCertificatePath;
            //            attachments.PersonalId = attach.PersonalId;
            //            _repositoryUnitOfWork.EmployeeAttachments.Value.Add(attachments);
            //            #endregion
            //        }
            //        else
            //        {
            //            #region Add Files Add File Name
            //            EmployeeAttachments employeeAttachments = fileUploaderHelper.UploadEmployeeAttachments(profile.Attachments);
            //            employeeAttachments.ApplicationUserId = user.Id;
            //            _repositoryUnitOfWork.EmployeeAttachments.Value.Add(employeeAttachments);
            //            #endregion
            //        }
            //    }
            //    #endregion

            //    #region Skills Update
            //    if (profile.Skills.Count > 0)
            //    {
            //        List<UserSkill> userSkill = _repositoryUnitOfWork.UserSkill.Value.Find(x => x.UserId == user.Id).ToList();
            //        if (userSkill.Count > 0)
            //        {
            //            _repositoryUnitOfWork.UserSkill.Value.RemoveRange(userSkill);

            //            List<UserSkill> skills = _mapper.Map<List<UserSkill>>(profile.Skills);
            //            foreach (UserSkill skill in skills)
            //            {
            //                skill.Id = 0;
            //            }
            //            _repositoryUnitOfWork.UserSkill.Value.AddRange(skills);
            //        }
            //        else
            //        {
            //            List<UserSkill> skills = _mapper.Map<List<UserSkill>>(profile.Skills);
            //            _repositoryUnitOfWork.UserSkill.Value.AddRange(skills);
            //        }
            //    }
            //    #endregion

            //    #region Experience update
            //    if (profile.Experiences.Count > 0)
            //    {
            //        List<Experience> experiences = _repositoryUnitOfWork.Experience.Value.Find(x => x.ApplicationUserId == user.Id).ToList();
            //        if (experiences.Count > 0)
            //        {
            //            _repositoryUnitOfWork.Experience.Value.RemoveRange(experiences);

            //            List<Experience> profileExperiance = _mapper.Map<List<Experience>>(profile.Experiences);
            //            foreach (Experience experience in profileExperiance)
            //            {
            //                experience.Id = 0;
            //            }
            //            _repositoryUnitOfWork.Experience.Value.AddRange(experiences);
            //        }
            //        else
            //        {
            //            List<Experience> profileExperiance = _mapper.Map<List<Experience>>(profile.Experiences);
            //            _repositoryUnitOfWork.Experience.Value.AddRange(experiences);
            //        }
            //    }
            //    #endregion

            //}

            user.ApprovalStatus = (int)ApprovalStatus.submittedForApproval;

            await _userManager.UpdateAsync(user);

            return profile;
        }
        public async Task<EmployeeAttachmentsAddUpdateDTO> UploadProfileAttachment(EmployeeAttachmentsAddUpdateDTO attachment)
        {
            if (attachment != null)
            {
                int userId = _loggedInUserService.GetUserId();
                ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                //EmployeeAttachments employeeAttachment = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);
                #region  AddEmployeeAttachments
                if (user.ApprovalStatus == (int)ApprovalStatus.New)
                {

                    EmployeeAttachments attach = fileUploaderHelper.UploadEmployeeAttachments(attachment);
                    //if (attach.PersonalPicturePath != null) employeeAttachment.PersonalPicturePath = attach.PersonalPicturePath;
                    //if (attach.NoCriminalRecordPath != null) employeeAttachment.NoCriminalRecordPath = attach.NoCriminalRecordPath; ;
                    //if (attach.PersonalId != null) employeeAttachment.PersonalId = attach.PersonalId;
                    //if (attach.LastEducationCertificatePath != null) employeeAttachment.LastEducationCertificatePath = attach.LastEducationCertificatePath;
                    _repositoryUnitOfWork.EmployeeAttachments.Value.Add(attach);


                }
                else if (user.ApprovalStatus == (int)ApprovalStatus.Decline || user.ApprovalStatus == (int)ApprovalStatus.submittedForApproval)
                {
                    #region Attachment Update

                    EmployeeAttachments attachments = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);

                    if (attachments != null)
                    {
                        #region Add The New Attachments And Upda
                        EmployeeAttachments attach = fileUploaderHelper.UploadEmployeeAttachments(attachment);
                        if (attach.PersonalPicturePath != null)
                        {
                            if (attachments.PersonalPicturePath != null)
                            {
                                fileUploaderHelper.DeleteFile(attachments.PersonalPicturePath);
                            }
                            
                            attachments.PersonalPicturePath = attach.PersonalPicturePath;
                        }
                        if (attach.NoCriminalRecordPath != null)
                        {
                            if (attachments.NoCriminalRecordPath != null)
                            {
                                fileUploaderHelper.DeleteFile(attachments.NoCriminalRecordPath);
                            }
                            attachments.NoCriminalRecordPath = attach.NoCriminalRecordPath;
                        }
                        if (attach.LastEducationCertificatePath != null)
                        {
                            if (attachments.LastEducationCertificatePath != null)
                            {
                                fileUploaderHelper.DeleteFile(attachments.LastEducationCertificatePath);
                            }
                            attachments.LastEducationCertificatePath = attach.LastEducationCertificatePath;
                        }
                        if (attach.PersonalId != null)
                        {
                            if (attachments.PersonalId != null)
                            {
                                fileUploaderHelper.DeleteFile(attachments.PersonalId);
                            }
                            attachments.PersonalId = attach.PersonalId;
                        }
                        _repositoryUnitOfWork.EmployeeAttachments.Value.Update(attachments);
                        #endregion
                    }
                    else
                    {
                        #region Add Files Add File Name
                        EmployeeAttachments employeeAttachments = fileUploaderHelper.UploadEmployeeAttachments(attachment);
                        employeeAttachments.ApplicationUserId = user.Id;
                        _repositoryUnitOfWork.EmployeeAttachments.Value.Add(employeeAttachments);
                        #endregion
                    }

                    #endregion
                }

                #endregion

                return attachment;
            }
            
            return attachment;
        }
        public EmployeeResponseDTO GetProfile()
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            List<Experience> experience = _repositoryUnitOfWork.Experience.Value.Find(x => x.ApplicationUserId == userId, x => x.CreatedBy, x => x.ModifiedBy).ToList();
            List<UserSkillDTO> skills = _repositoryUnitOfWork.UserSkill.Value.GetByUserId(userId).ToList();

            EmployeeResponseDTO employee = new EmployeeResponseDTO();

            if (experience != null)
            {
                List<ExperienceDTO> experienceDTOs = _mapper.Map<List<ExperienceDTO>>(experience);
                employee.UserExperience = experienceDTOs;
            }

            if (skills != null)
            {
                employee.UserSkill = skills;
            }

            employee.Id = userId;
            employee.Latitude = user.Latitude;
            employee.Longitude = user.Longitude;
            employee.FullName = user.FullName;
            employee.LastEducationLevel = user.LastEducationLevel;
            employee.YearOfBirth = user.YearOfBirth;
            employee.Gender = user.Gender;
            employee.NoPrevExperience = user.NoPrevExperience;

            return employee;

        }

        public async Task<EmployeeAttachments> GetEmployeeAttachments()
        {
            int userId = _loggedInUserService.GetUserId();
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            EmployeeAttachments employeeAttachments = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);
            return employeeAttachments;
        }

        public EmployeeResponseDTO GetProfileById(int userId)
        {
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            List<Experience> experience = _repositoryUnitOfWork.Experience.Value.Find(x => x.ApplicationUserId == userId, x => x.CreatedBy, x => x.ModifiedBy).ToList();
            List<UserSkill> skills = _repositoryUnitOfWork.UserSkill.Value.Find(x => x.UserId == userId, x => x.Skill ,x =>x.CreatedBy , x =>x.ModifiedBy).ToList();
            EmployeeAttachments attachment = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);

            EmployeeResponseDTO employee = new EmployeeResponseDTO();

            if (experience != null)
            {
                List<ExperienceDTO> experienceDTOs = _mapper.Map<List<ExperienceDTO>>(experience);
                employee.UserExperience = experienceDTOs;
            }

            if (skills != null)
            {
                List<UserSkillDTO> userSkills = _mapper.Map<List<UserSkillDTO>>(skills);
                employee.UserSkill = userSkills;
            }

            if (attachment != null)
            {
                EmployeeAttachmentDTO attachmentDTO = _mapper.Map<EmployeeAttachmentDTO>(attachment);
                employee.Attachment = attachmentDTO;

            }

            employee.Id = userId;
            employee.PhoneNumber = user.PhoneNumber;
            employee.Latitude = user.Latitude;
            employee.Longitude = user.Longitude;
            employee.FullName = user.FullName;
            employee.YearOfBirth = user.YearOfBirth;
            employee.Gender = user.Gender;
            employee.UserName = user.UserName;
            employee.CreationDate = user.CreationDate.ToString();

            return employee;

        }

        public async Task<bool> DeleteEmployeeSkill(int Id)
        {
            return _repositoryUnitOfWork.UserSkill.Value.Remove(Id);
        }
        public async Task<bool> DeleteEmployeeExperience(int Id)
        {
            return _repositoryUnitOfWork.Experience.Value.Remove(Id);
        }

    }
}

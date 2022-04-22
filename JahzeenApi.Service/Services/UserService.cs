using AutoMapper;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.Models.Common;
using Domain.SearchModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains.SearchModels;
using Domains.DTO;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private LoggedInUserService _loggedInUserService;
        private IMapper _mapper;
        AppConfiguration _appConfiguration = new AppConfiguration();

        public UserService(UserManager<ApplicationUser> userManager, IRepositoryUnitOfWork repositoryUnitOfWork, LoggedInUserService loggedInUserService, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _userManager = userManager;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        //For Admin
        public async Task<UserResponseDTO> Register(RegisterDTO model)
        {
            if (_userManager.Users.Any(x => x.PhoneNumber == model.PhoneNumber))
            {
                throw new ValidationException("Phone Number Already Exists");
            }
            if (_userManager.Users.Any(x => x.UserName == model.UserName))
            {
                throw new ValidationException("UserName Already Exists");
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                IsActive = true,
                PhoneNumber = model.PhoneNumber,
                //Address = model.Address,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                CreatedBy = _loggedInUserService.GetUserName(),
                CreationDate = DateTime.Now
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _repositoryUnitOfWork.UserRoles.Value.Add(new UserRoles
                {
                    RoleId = model.RoleId,
                    UserId = user.Id,
                });
                return _mapper.Map<UserResponseDTO>(user);
            }
            else
            {
                throw new ValidationException("Error While Creating User");
            }
        }

        public async Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userInfo.Id.ToString());

            user.Email = userInfo.Email;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.FullName = userInfo.FullName;
            //user.Address = userInfo.Address;
            user.IsActive = userInfo.IsActive;
            user.Longitude = userInfo.Longitude;
            user.Latitude = userInfo.Latitude;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }

        public async Task<bool> RemoveUser(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else if (result.Errors.Any())
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            else
            {
                throw new Exception("Error while removing user");
            }
        }

        public async Task<UserResponseDTO> GetUserInfo(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);
            return userDTO;
        }

        public async Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search)
        {
            List<ApplicationUser> users = await _userManager.Users.Where(x =>
                                                 (string.IsNullOrEmpty(search.SearchValue) ||
                                                 (x.FullName.Contains(search.SearchValue) || x.UserName.Contains(search.SearchValue) || x.Email.Contains(search.SearchValue) || x.PhoneNumber.Contains(search.SearchValue))) &&
                                                 (!search.RoleType.HasValue || x.UserRoles.Any(y => y.RoleId == search.RoleType)) &&
                                                 (!search.IsActive.HasValue || x.IsActive == search.IsActive)).ToListAsync();

            int pageCount = users.Count();

            users = users.Skip(_appConfiguration.PageSize * (search.PageNumber - 1)).Take(_appConfiguration.PageSize).ToList();

            ListResponse<UserResponseDTO> UsersListResponse = new ListResponse<UserResponseDTO>
            {
                entities = _mapper.Map<List<UserResponseDTO>>(users),
                TotalCount = pageCount
            };

            return UsersListResponse;
        }
        public BaseListResponse<RegisteredUserResponseDTO> GetRegisteredUsers(UserSearch search)
        {
            BaseListResponse<RegisteredUserResponseDTO> users = _repositoryUnitOfWork.Users.Value.GetRegisteredUsers(search);
            return users;
        }


        // For LoggedIn User
        public async Task<UserProfileResponseDTO> GetUserProfile()
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserProfileResponseDTO userProfileDTO = _mapper.Map<UserProfileResponseDTO>(user);
            return userProfileDTO;
        }

        public async Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile)
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            user.Email = userProfile.Email;
            user.PhoneNumber = userProfile.PhoneNumber;
            user.FullName = userProfile.FullName;
            //user.Address = userProfile.Address;
            user.Latitude = userProfile.Latitude;
            user.Longitude = userProfile.Longitude;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserProfileResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }

        public IList<RoleDTO> GetRoles()
        {
            IList<RoleDTO> roles = _repositoryUnitOfWork.UserRoles.Value.GetRoles();
            return roles;
        }
    }
}

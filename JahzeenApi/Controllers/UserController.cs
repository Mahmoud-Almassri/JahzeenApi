﻿using JahzeenApi.Domain.DTO;
using Domain.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System.Threading.Tasks;
using Domains.SearchModels;
using Domains.DTO;

namespace JahzeenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public UserController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            UserResponseDTO applicationUser = await _serviceUnitOfWork.User.Value.Register(registerDTO);
            return Ok(applicationUser);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            bool result = await _serviceUnitOfWork.User.Value.RemoveUser(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserInfo(UserRequestDTO userInfo)
        {
            var user = await _serviceUnitOfWork.User.Value.UpdateUserInfo(userInfo);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _serviceUnitOfWork.User.Value.GetUserInfo(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> GetList(UserSearchModel search)
        {
            ListResponse<UserResponseDTO> usersList = await _serviceUnitOfWork.User.Value.GetUsersList(search);
            return Ok(usersList);

        }
        [HttpPost]
        public IActionResult GetRegisteredUsers(UserSearch search)
        {
            try
            {
                BaseListResponse<RegisteredUserResponseDTO> usersList = _serviceUnitOfWork.User.Value.GetRegisteredUsers(search);
                return Ok(usersList);
            }
            catch (System.Exception e)
            {

                throw;
            }
           

        }



        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _serviceUnitOfWork.User.Value.GetUserProfile();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(UserProfileRequestDTO userProfile)
        {
            var user = await _serviceUnitOfWork.User.Value.UpdateUserProfile(userProfile);
            return Ok(user);
        }
    }
}

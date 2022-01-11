﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkAPI.Models;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;

namespace NetworkAPI.Controllers
{
    /// <summary>
    /// Controller for working with users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for creating of user controller with given services and mapper profile
        /// </summary>
        /// <param name="mapper">Auto mapper profile for models and dtos</param>
        /// <param name="userService">User service</param>
        /// <param name="userProfileService">User profile service</param>
        public UserController(IUserService userService,
            IUserProfileService userProfileService, IMapper mapper)
        {
            _userService = userService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        /// <summary>
        /// To get all users profiles with details
        /// </summary>
        /// <returns>Collection of users profiles</returns>
        [HttpGet]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetAllUserProfilesWithDetails()
        {
            var users = await _userProfileService.GetAllProfilesWithDetailsAsync();
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(users));
        }

        /// <summary>
        /// To get user profile by its id allowed for all users
        /// </summary>
        /// <param name="id">The id of user whose detailed profile should be found</param>
        /// <returns>Found user profile</returns>
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<UserProfileModel>> GetUserProfileByIdForAll(int id)
        {
            var userProfileDto = await _userProfileService.GetProfileByIdWithDetailsAsync(id);
            return Ok(_mapper.Map<UserProfileModel>(userProfileDto));
        }

        /// <summary>
        /// To get all user roles
        /// </summary>
        /// <returns>Collection of role names</returns>
        [HttpGet]
        [Route("Roles")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<string>>> GetUserRoles()
        {
            return Ok(await _userService.GetAllUserRoles(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        /// <summary>
        /// To get own user profile after autorirization
        /// </summary>
        /// <returns>User profile of authorized user</returns>
        [HttpGet]
        [Route("YourProfile")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<UserProfileDto>> GetAuthorizedUserProfile()
        {
            var user = await _userProfileService.GetProfileByIdWithDetailsAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(user);
        }

        /// <summary>
        /// To change your own password
        /// </summary>
        /// <param name="passwordModel">The instance with data for changing password</param>
        /// <returns>Successfull status code if all is Ok</returns>
        [HttpPut]
        [Route("ChangePassword")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> ChangeUserPassword([FromBody] ChangePasswordModel passwordModel)
        {
            await _userService.ChangeUserPasswordAsync(
                Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                passwordModel.OldPassword, passwordModel.NewPassword);
            return Ok();
        }

        /// <summary>
        /// To get user profile with all details by his email
        /// </summary>
        /// <param name="email">The email of user who should be found</param>
        /// <returns>Found user</returns>
        [HttpPost]
        [Route("GetByEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserProfileModel>> GetUserProfileWithDetailsByEmail([FromBody]string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            var fullUser = await _userProfileService.GetProfileByIdWithDetailsAsync(user.Id);
            return Ok(_mapper.Map<UserProfileModel>(fullUser));
        }

        /// <summary>
        /// To get user profile with all details by his user name
        /// </summary>
        /// <param name="name">The user name of user who should be found</param>
        /// <returns>Found user</returns>
        [HttpGet]
        [Route("GetByUserName/{name}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<UserProfileModel>> GetUserProfileWithDetailsByUserName(string name)
        {
            var user = _userService.GetUserByUserName(name);
            var fullUser = await _userProfileService.GetProfileByIdWithDetailsAsync(user.Id);
            return Ok(_mapper.Map<UserProfileModel>(fullUser));
        }

        /// <summary>
        /// To get user profile with all details by his full name
        /// </summary>
        /// <param name="first">The first name of user who should be found</param>
        /// <param name="last">The last name of user who should be found</param>
        /// <returns>Found user</returns>
        [HttpGet]
        [Route("GetByFullName/{first}/{last}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetUserProfileWithDetailsByFullName(string first, string last)
        {
            var users = _userService.GetUsersByFirstAndLastName(first, last);
            var usersProfiles = new List<UserProfileDto>();
            foreach (var user in users)
            {
                var profile = await _userProfileService.GetProfileByIdWithDetailsAsync(user.Id);
                usersProfiles.Add(profile);
            }
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(usersProfiles));
        }

        /// <summary>
        /// To get user profile with all details by his phone number
        /// </summary>
        /// <param name="phoneNumber">The phone number of user who should be found</param>
        /// <returns>Found user</returns>
        [HttpPost]
        [Route("GetByPhone")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<UserProfileModel>> GetUserProfileWithDetailsByPhone([FromBody]string phoneNumber)
        {
            var user = await _userService.GetUserByPhoneNumberAsync(phoneNumber);
            var fullUser = await _userProfileService.GetProfileByIdWithDetailsAsync(user.Id);
            return Ok(_mapper.Map<UserProfileModel>(fullUser));
        }

        /// <summary>
        /// To add chosen user to chosen role
        /// </summary>
        /// <param name="id">The id of user who should be added to role</param>
        /// <param name="role">The role name where user should be added to</param>
        /// <returns>Result status code</returns>
        [HttpPost]
        [Route("AddRole/{id}/{role}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddUserToRole(int id, string role)
        {
            await _userService.AddUserToRoleAsync(id, role);
            return Ok();
        }

        /// <summary>
        /// To update user info by this user
        /// </summary>
        /// <param name="userModel">Changed data of user</param>
        /// <returns>Updated user profile</returns>
        [HttpPut]
        [Route("UpdateYourInfo")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<UserProfileDto>> UpdateUserInfoByUser([FromBody] UserModel userModel)
        {
            var userToChange = _mapper.Map<UserDto>(userModel);
            userToChange.Id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _userService.UpdateUserInfoAsync(userToChange);
            var changedProfile = await _userProfileService.GetProfileByIdWithDetailsAsync(userToChange.Id);
            return Ok(changedProfile);
        }

        /// <summary>
        /// To update user info by admin
        /// </summary>
        /// <param name="userModel">Changed data of user</param>
        /// <param name="id">The id user whose information should changed</param>
        /// <returns>Updated user profile</returns>
        [HttpPut]
        [Route("UpdateUserInfo")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserProfileModel>> UpdateUserInfoByAdmin(int id, [FromBody] UserModel userModel)
        {
            var userToChange = _mapper.Map<UserDto>(userModel);
            userToChange.Id = id;
            await _userService.UpdateUserInfoAsync(userToChange);
            var changedProfile = await _userProfileService.GetProfileByIdWithDetailsAsync(userToChange.Id);
            return Ok(_mapper.Map<UserProfileModel>(changedProfile));
        }

        /// <summary>
        /// To delete user because of his own desire
        /// </summary>
        /// <returns>Result status code</returns>        
        [HttpDelete]
        [Route("DeleteOwnAccount")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> DeleteUserByHimself()
        {
            await _userService.DeleteUserByIdAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok();
        }

        /// <summary>
        /// To delete any user by admin
        /// </summary>
        /// <param name="id">The id of user who should be deleted</param>
        /// <returns>Result status code</returns>
        [HttpDelete]
        [Route("DeleteUserByAdmin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserByAdmin(int id)
        {
            await _userService.DeleteUserByIdAsync(id);
            return Ok();
        }



    }
}
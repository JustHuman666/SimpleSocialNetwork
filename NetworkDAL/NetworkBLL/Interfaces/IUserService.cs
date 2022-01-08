﻿using Microsoft.AspNetCore.Identity;
using NetworkBLL.EntetiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Interfaces
{
    /// <summary>
    /// Service interface for working with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// To add a new instance of user with chosen role
        /// </summary>
        /// <param name="newUser">The instance of new user</param>
        /// <param name="password">The password of new user</param>
        /// <returns>The identity result with information about final result</returns>
        Task CreateUserWithRoleAsync(UserDto newUser, string password, string role);

        /// <summary>
        /// To change password for chosen user
        /// </summary>
        /// <param name="id">The id of user whose password should be changed</param>
        /// <param name="oldPassword">Current password of this user</param>
        /// <param name="newPassword">New password that will be next</param>
        /// <returns>The identity result with information about final result</returns>
        Task<IdentityResult> ChangeUserPasswordAsync(int id, string oldPassword, string newPassword);

        /// <summary>
        /// To get an instance of the user with such email
        /// </summary>
        /// <param name="email">The email of user who is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUserByEmailAsync(string email);

        /// <summary>
        /// To get an instance of the user with such phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number of user who is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUserByPhoneNumberAsync(string phoneNumber);

        /// <summary>
        /// To check if password is correct and true for this user
        /// </summary>
        /// <param name="id">The id of user whose password is compared with given</param>
        /// <param name="password">The password which is checked</param>
        /// <returns>Boolean representing of result of this operation</returns>
        Task<bool> CheckUserPasswordAsync(int id, string password);

        /// <summary>
        /// Add chosen user to chosen role
        /// </summary>
        /// <param name="id">The id of user who should be added to the role</param>
        /// <param name="role">The name of role for this user</param>
        /// <returns>The identity result with information about final result</returns>
        Task<IdentityResult> AddUserToRoleAsync(int id, string role);

        /// <summary>
        /// To get all roles for chosen user
        /// </summary>
        /// <param name="id">The id of user whose roles are finding</param>
        /// <returns>Collection of all roles names</returns>
        Task<IEnumerable<string>> GetAllUserRoles(int id);

        /// <summary>
        ///  To update some information about chosen user 
        /// </summary>
        /// <param name="user">The instance of user that should be changed</param>
        Task UpdateUserInfoAsync(UserDto user);

        /// <summary>
        /// To delete chosen user by user id
        /// </summary>
        /// <param name="id">Id of user who should be deleted</param>
        Task DeleteUserByIdAsync(int id);

        /// <summary>
        /// To get an instance of user by user id
        /// </summary>
        /// <param name="id">Id of user who is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUserByIdAsync(int id);

        /// <summary>
        /// To get an instance of user by username
        /// </summary>
        /// <param name="userName">Username of user who is found</param>
        /// <returns>An instance of found user</returns>
        UserDto GetUserByUserNameAsync(string userName);

        /// <summary>
        /// To get a collection of users by user full name
        /// </summary>
        /// <param name="firstName">Firstname of user who is found</param>
        /// <param name="lastName">Lastname of user who is found</param>
        /// <returns>Collection of found users</returns>
        IQueryable<UserDto> GetUsersByFirstAndLastName(string firstName, string lastName);

        /// <summary>
        /// To get a collection of all users 
        /// </summary>
        /// <returns>Queryable collection of users</returns>
        IQueryable<UserDto> GetAllUsers();

        /// <summary>
        /// To get an instance of user with additional information 
        /// </summary>
        /// <param name="id">The id of user that is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUserByIdWithDetailsAsync(int id);

        /// <summary>
        /// To send an invitation to be a friend of chosen user
        /// </summary>
        /// <param name="userId">The id of user who want to ba e friend</param>
        /// <param name="wantedFriendId">The id of user who is wanted to be a friend</param>
        Task SendInvitationForFriendshipAsync(int userId, int wantedFriendId);

        /// <summary>
        /// To confirm friendship between users
        /// </summary>
        /// <param name="userId">The id of user who get the invitation</param>
        /// <param name="friendId">The id user who wait for confirm</param>
        Task ConfirmFriendsip(int userId, int friendToConfirmId);

        /// <summary>
        /// To delete user from friends
        /// </summary>
        /// <param name="userId">The id of user who want to delete this friend</param>
        /// <param name="friendToDeleteId">The id of friend who should be deleted</param>
        Task DeleteFriendByFriendId(int userId, int friendToDeleteId);
    }
}

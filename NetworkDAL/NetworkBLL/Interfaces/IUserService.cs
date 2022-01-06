using Microsoft.AspNetCore.Identity;
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
        /// <param name="user">The instance of user whose password should be changed</param>
        /// <param name="oldPassword">Current password of this user</param>
        /// <param name="newPassword">New password that will be next</param>
        /// <returns>The identity result with information about final result</returns>
        Task<IdentityResult> ChangeUserPasswordAsync(UserDto user, string oldPassword, string newPassword);

        /// <summary>
        /// To get an instance of the user with such email
        /// </summary>
        /// <param name="email">The email of user who is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUserByEmailAsync(string email);

        /// <summary>
        /// To check if password is correct and true for this user
        /// </summary>
        /// <param name="user">The instance of user whose password is compared with given</param>
        /// <param name="password">The password which is checked</param>
        /// <returns>Boolean representing of result of this operation</returns>
        Task<bool> CheckUserPasswordAsync(UserDto user, string password);

        /// <summary>
        /// Add chosen user to chosen role
        /// </summary>
        /// <param name="user">The instance of user who should be added to the role</param>
        /// <param name="role">The name of role for this user</param>
        /// <returns>The identity result with information about final result</returns>
        Task<IdentityResult> AddUserToRoleAsync(UserDto user, string role);

        /// <summary>
        /// To get all roles for chosen user
        /// </summary>
        /// <param name="user">The instance of user whose roles are found</param>
        /// <returns>Collection of all roles names</returns>
        Task<IEnumerable<string>> GetAllUserRoles(UserDto user);

        /// <summary>
        ///  To update some information about chosen user 
        /// </summary>
        /// <param name="user">The instance of user that should be changed</param>
        Task UpdateUSerInfoAsync(UserDto user);

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
        Task<UserDto> GetUSerByIdAsync(int id);

        /// <summary>
        /// To get a collection of all users 
        /// </summary>
        /// <returns>Queryable collection of users</returns>
        Task<IQueryable<UserDto>> GetUsersAsync();

        /// <summary>
        /// To get an instance of user with additional information 
        /// </summary>
        /// <param name="id">The id of user that is found</param>
        /// <returns>An instance of found user</returns>
        Task<UserDto> GetUSerByIdWithDetailsAsync(int id);
    }
}

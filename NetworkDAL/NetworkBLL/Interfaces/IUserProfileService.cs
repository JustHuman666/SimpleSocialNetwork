using NetworkBLL.EntetiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Interfaces
{
    /// <summary>
    /// Service interface for working with users profiles
    /// </summary>
    public interface IUserProfileService
    {
        /// <summary>
        /// To get an instance of user profile by its id
        /// </summary>
        /// <param name="id">Id of profile that is found</param>
        /// <returns>An instance of found user profile</returns>
        Task<UserProfileDto> GetProfileByIdAsync(int id);

        /// <summary>
        /// To get all friends of chosen user
        /// </summary>
        /// <param name="id">The id of user whose friends should be found</param>
        /// <returns>Collection of users profiles who are confirmed friends of this user</returns>
        Task<IQueryable<UserProfileDto>> GetUserFriendsByIdAsync(int id);

        /// <summary>
        /// To get all invitation to be a friend for chosen user
        /// </summary>
        /// <param name="id">The id of user whose invitations should be found</param>
        /// <returns>Collection of users profiles who are not confirmed as friends of this user</returns>
        Task<IQueryable<UserProfileDto>> GetUserInvitationByIdAsync(int id);

        /// <summary>
        /// To get an instance of user profile with additional information 
        /// </summary>
        /// <param name="id">The id of user profile that is found</param>
        /// <returns>An instance of found user profile</returns>
        Task<UserProfileDto> GetProfileByIdWithDetailsAsync(int id);

        /// <summary>
        /// To get a collection of user profiles with additional information
        /// </summary>
        /// <returns>Queryable collection of all users profiles</returns>
        Task<IQueryable<UserProfileDto>> GetAllProfilesWithDetailsAsync();
    }
}

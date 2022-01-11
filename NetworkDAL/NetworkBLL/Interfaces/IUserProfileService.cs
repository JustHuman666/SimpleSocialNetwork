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
        Task<IEnumerable<UserProfileDto>> GetUserFriendsByIdAsync(int id);

        /// <summary>
        /// To get all invitation to be a friend for chosen user
        /// </summary>
        /// <param name="id">The id of user whose invitations should be found</param>
        /// <returns>Collection of users profiles who are not confirmed as friends of this user</returns>
        Task<IEnumerable<UserProfileDto>> GetUserInvitationByIdAsync(int id);

        /// <summary>
        /// To get all invitations that this user sent
        /// </summary>
        /// <param name="userId">The id of user who sent invitationc</param>
        Task<IEnumerable<UserProfileDto>> GetAllInvitationsWhichUSerSentById(int userId);

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
        Task<IEnumerable<UserProfileDto>> GetAllProfilesWithDetailsAsync();

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

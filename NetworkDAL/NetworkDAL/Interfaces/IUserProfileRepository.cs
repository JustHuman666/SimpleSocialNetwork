using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDAL.Interfaces
{
    /// <summary>
    /// An interface for user profiles repository
    /// </summary>
    public interface IUserProfileRepository : IDetailsRepository<UserProfile>
    {
        /// <summary>
        /// To get an instance of user profile by its id
        /// </summary>
        /// <param name="id">Id of profile that is found</param>
        /// <returns>An instance of found user profile</returns>
        Task<UserProfile> GetByIdAsync(int id);

        /// <summary>
        /// To get all frieds of chosen user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of all confirmedfriends</returns>
        Task<IQueryable<UserProfile>> GetUserFriendsByIdAsync(int id);

        /// <summary>
        /// To get all invitation to be a friend of chosen user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of all invitation</returns>
        Task<IQueryable<UserProfile>> GetInvitationForFriendshipByIdAsync(int id);
    }
}

using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
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
    }
}

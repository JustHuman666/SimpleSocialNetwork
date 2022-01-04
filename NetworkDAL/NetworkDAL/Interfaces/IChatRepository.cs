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
    /// Repository interface for working with chat
    /// </summary>
    public interface IChatRepository : IRepository<Chat>, IDetailsRepository<Chat> 
    {
        /// <summary>
        /// To get all users of chosen chat
        /// </summary>
        /// <param name="id">The id of chat</param>
        /// <returns>Collection of users who are in this chat</returns>
        Task<IQueryable<UserProfile>> GetUsersOfChatAsync(int id);

        /// <summary>
        /// To get all chats of chosen user
        /// </summary>
        /// <param name="id">The id of user whose chats should be found</param>
        /// <returns>Collection of chats of this user</returns>
        Task<IQueryable<Chat>> GetChatsByUserId(int id);
    }
}

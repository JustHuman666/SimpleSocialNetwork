using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDAL.Interfaces
{
    public interface IChatRepository : IRepository<Chat>, IDetailsRepository<Chat> 
    {
        /// <summary>
        /// To get all chats where is chosen user in
        /// </summary>
        /// <param name="id">The id user whose chats are found</param>
        /// <returns>Collection of all chats of this user</returns>
        Task<IQueryable<Chat>> GetUserChatsById(int id);
    }
}

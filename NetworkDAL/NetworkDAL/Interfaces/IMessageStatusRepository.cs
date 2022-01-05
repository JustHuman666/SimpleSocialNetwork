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
    /// Repository interface for getting some information about message statuses
    /// </summary>
    public interface IMessageStatusRepository : IDetailsRepository<MessageStatus>
    {

        /// <summary>
        /// To get all possible statuses from db
        /// </summary>
        /// <returns>Collection of instances of all message statuses from db</returns>
        Task<IQueryable<MessageStatus>> GetAllAsync();

        /// <summary>
        /// To get message status by its id
        /// </summary>
        /// <param name="id">The id of status that is found</param>
        /// <returns>Instance of found status</returns>
        Task<MessageStatus> GetByIdAsync(int id);
    }
}

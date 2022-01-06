using NetworkBLL.EntetiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Interfaces
{
    /// <summary>
    /// Service repository for working with message statuses
    /// </summary>
    public interface IMessageStatusService
    {
        /// <summary>
        /// To get all possible statuses from db
        /// </summary>
        /// <returns>Collection of instances of all message statuses from db</returns>
        Task<IQueryable<MessageStatusDto>> GetAllMessageStatusesAsync();

        /// <summary>
        /// To get message status by its id
        /// </summary>
        /// <param name="id">The id of status that is found</param>
        /// <returns>Instance of found status</returns>
        Task<MessageStatusDto> GetMessageStatusByIdAsync(int id);

        /// <summary>
        /// To get an instance of message status with additional information from DB
        /// </summary>
        /// <param name="id">The id message status that is found</param>
        /// <returns>An instance of found message status</returns>
        Task<MessageStatusDto> GetMessageStatusByIdWithDetailsAsync(int id);

        /// <summary>
        /// To get aa collection of message status with additional information from DB
        /// </summary>
        /// <returns>Queryable collection of all message status</returns>
        Task<IQueryable<MessageStatusDto>> GetAllMessageStatusesWithDetailsAsync();
    }
}

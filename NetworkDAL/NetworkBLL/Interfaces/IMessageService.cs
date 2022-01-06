using NetworkBLL.EntetiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Interfaces
{
    /// <summary>
    /// Service interface for working with messages
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// To send a new message in chat
        /// </summary>
        /// <param name="item">The instance of new message that should be sent</param>
        Task SendMessageInChatAsync(MessageDto item);

        /// <summary>
        /// To resend message from one chat to another as new, but with original sender info
        /// </summary>
        /// <param name="item">The instance of message that should be resent</param>
        /// <param name="chatId">The id of where this message should be resent</param>
        Task ResendMessageToAnotherChatAsync(MessageDto item, int chatId);

        /// <summary>
        /// To edit a text of chosen message
        /// </summary>
        /// <param name="item">The instance of message that should be changed</param>
        Task EditMessageTextAsync(MessageDto item);

        /// <summary>
        /// To update a status of chosen message
        /// </summary>
        /// <param name="item">The instance of message that should be changed</param>
        Task UpdateMessageStatusAsync(MessageDto item);

        /// <summary>
        /// To delete chosen message for all users in the chat
        /// </summary>
        /// <param name="id">Id of message that should be deleted</param>
        Task DeleteMessageForAllUsersAsync(int id);

        /// <summary>
        /// To delete chosen message only for one user
        /// </summary>
        /// <param name="id">Id of message that should be deleted</param>
        Task DeleteMessageForOneUserAsync(int id);

        /// <summary>
        /// To get an instance of message by its id
        /// </summary>
        /// <param name="id">Id of message that is found</param>
        /// <returns>An instance of found message</returns>
        Task<MessageDto> GetMessageByIdAsync(int id);

        /// <summary>
        /// To get a collection of all messages
        /// </summary>
        /// <returns>Queryable collection of messages</returns>
        Task<IQueryable<MessageDto>> GetAllMessagesAsync();

        /// <summary>
        /// To get a collection of all messages in chosen chat
        /// </summary>
        /// <param name="id">The id of chat whish messages are finding</param>
        /// <returns>Queryable collection of message/returns>
        Task<IQueryable<MessageDto>> GetAllMessagesByChatIdAsync(int id);
    }
}

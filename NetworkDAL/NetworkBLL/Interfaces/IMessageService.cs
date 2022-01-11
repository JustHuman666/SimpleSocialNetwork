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
        /// <param name="messageId">The id of message that should be resent</param>
        /// <param name="chatId">The id of chat where this message should be resent</param>
        /// <param name="senderId">The id of user who want to resend this message</param>
        Task ResendMessageToChosenChatAsync(int messageId, int chatId, int senderId);

        /// <summary>
        /// To edit a text of chosen message
        /// </summary>
        /// <param name="item">The instance of message that should be changed</param>
        /// <param name="senderId">The id of sender who can edit this message</param>
        Task EditMessageTextAsync(MessageDto item, int senderId);

        /// <summary>
        /// To update a status of chosen message
        /// </summary>
        /// <param name="messageId">The id of message which status should be changed</param>
        Task UpdateMessageStatusAsync(int messageId);

        /// <summary>
        /// To delete chosen message for all users in the chat
        /// </summary>
        /// <param name="id">Id of message that should be deleted</param>
        Task DeleteMessageAsync(int id);

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
        Task<IEnumerable<MessageDto>> GetAllMessagesAsync();

        /// <summary>
        /// To get a collection of all messages in chosen chat
        /// </summary>
        /// <param name="id">The id of chat whish messages are finding</param>
        /// <returns>Collection of message/returns>
        Task<IEnumerable<MessageDto>> GetAllMessagesByChatIdAsync(int id);
    }
}

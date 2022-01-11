using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkAPI.Models;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;

namespace NetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly IUserProfileService _userProfileService;

        /// <summary>
        /// Constructor for creating of controller with given services and mapper profile
        /// </summary>
        /// <param name="mapper">Auto mapper profile for models and dtos</param>
        /// <param name="messageService">Chat service</param>
        /// <param name="userProfileService">USer profile service</param>
        public MessageController(IMessageService messageService, IUserProfileService userProfileService, IMapper mapper)
        {
            _messageService = messageService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        /// <summary>
        /// To send a new message in chat
        /// </summary>
        /// <param name="messageModel">The instance of new message that should be sent</param>
        [HttpPost]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> SendMessageInChat([FromBody]MessageModel messageModel)
        {
            messageModel.SenderId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _messageService.SendMessageInChatAsync(_mapper.Map<MessageDto>(messageModel));
            return Ok();
        }

        /// <summary>
        /// To resend message from one chat to another as new, but with original sender info
        /// </summary>
        /// <param name="messageId">The id of message that should be resent</param>
        /// <param name="chatId">The id of chat where this message should be resent</param>
        [HttpPost]
        [Route("Resend/{messageId}/{chatId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> ResendSendMessageToChat(int messageId, int chatId)
        {
            var senderId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _messageService.ResendMessageToChosenChatAsync(messageId, chatId, senderId);
            return Ok();
        }

        /// <summary>
        /// To edit a text of chosen message
        /// </summary>
        /// <param name="messageModel">The instance of message that should be changed</param>
        /// <param name="messageId">The id of sender who can edit this message</param>
        [HttpPut]
        [Route("{messageId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> EditMessageText(int messageId, [FromBody]MessageModel messageModel)
        {
            var senderId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var message = await _messageService.GetMessageByIdAsync(messageId);
            message.Text = messageModel.Text;
            await _messageService.EditMessageTextAsync(message, senderId);
            return Ok();
        }

        /// <summary>
        /// To update a status of chosen message
        /// </summary>
        /// <param name="messageId">The id of message which status should be changed</param>
        [HttpPut]
        [Route("UpdateStatus/{messageId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> UpdateMessageStatus(int messageId)
        {
            await _messageService.UpdateMessageStatusAsync(messageId);
            return Ok();
        }

        /// <summary>
        /// To delete chosen message for all users in the chat
        /// </summary>
        /// <param name="id">Id of message that should be deleted</param>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return Ok();
        }

        /// <summary>
        /// To get an instance of message by its id
        /// </summary>
        /// <param name="id">Id of message that is found</param>
        /// <returns>An instance of found message</returns>
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<MessageDto>> GetMessageById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            return Ok(message);
        }

        /// <summary>
        /// To get a collection of all messages
        /// </summary>
        /// <returns>Collection of messages</returns>
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetAllMessages()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        /// <summary>
        /// To get a collection of all messages
        /// </summary>
        /// <returns>Collection of messages</returns>
        [HttpGet]
        [Route("GetMessagesOfChat/{id}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesOfChat(int id)
        {
            var messages = await _messageService.GetAllMessagesAsync();
            var messagesOfChat = messages.Where(message => message.ChatId == id);
            return Ok(messagesOfChat);
        }
    }
}
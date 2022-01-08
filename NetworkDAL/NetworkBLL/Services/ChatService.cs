using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;
using NetworkBLL.Validation;
using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Services
{
    /// <summary>
    /// Service for working with chats, message and users in them
    /// </summary>
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _db;

        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for creating of service with given unit of work (database and operations) and automapper profile
        /// </summary>
        /// <param name="database">Instance of unit of work for this service</param>
        /// <param name="mapper">Instance of automapper profile</param>
        public ChatService(IUnitOfWork database, IMapper mapper)
        {
            _db = database;
            _mapper = mapper;
        }

        public async Task AddUserInChatAsync(int chatId, int userId)
        {
            var chat = await _db.Chats.GetByIdAsync(chatId);
            if(chat ==null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            var user = await _db.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User does not exist");
            }
            var chatDto = _mapper.Map<ChatDto>(chat);
            if(chatDto.UserIds.Contains(userId))
            {
                throw new NetworkException("This user is already in this chat");
            }
            chatDto.UserIds.Add(userId);
            _db.Chats.Update(_mapper.Map<Chat>(chatDto));
            await _db.SaveAsync();
        }

        public async Task ClearChatHistoryByIdAsync(int id)
        {
            var chat = await _db.Chats.GetByIdAsync(id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            if(chat.Messages.Count() == 0 || chat.Messages == null)
            {
                throw new NotFoundException("Chat does not have any message");
            }
            var messages = await _db.Messages.GetAllAsync();
            var chatMessages = messages.Where(message => message.ChatId == id);
            foreach (var message in chatMessages)
            {
                _db.Messages.Delete(message.Id);
            }
            await _db.SaveAsync();
        }

        public async Task CreateChatAsync(ChatDto item)
        {
            if(item == null)
            {
                throw new NetworkException("Chat cannot be null");
            }
            if (item.UserIds.Count() < 1)
            {
                throw new NetworkException("Chat should consist of at least one user");
            }
            var chats = await _db.Chats.GetAllAsync();
            var chatsDto = _mapper.Map<IQueryable<ChatDto>>(chats);
            if(item.UserIds.Count == 1 && chatsDto.Any(chat => chat.UserIds == item.UserIds))
            {
                throw new NetworkException("Cannot create more than one chat with one user for this user");
            }
            if(string.IsNullOrEmpty(item.ChatName))
            {
                throw new NetworkException("Chat name cannot be null or empty");
            }
            item.CreationDate = DateTime.Now;
            await _db.Chats.CreateAsync(_mapper.Map<Chat>(item));
            await _db.SaveAsync();
        }

        public async Task DeleteChatAsync(int id)
        {
            var chat = await _db.Chats.GetByIdAsync(id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            _db.Chats.Delete(id);
            await _db.SaveAsync();
        }

        public async Task DeleteUserFromChatAsync(int chatId, int userId)
        {
            var chat = await _db.Chats.GetByIdAsync(chatId);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            var chatDto = _mapper.Map<ChatDto>(chat);
            if(!chatDto.UserIds.Contains(userId))
            {
                throw new NotFoundException("This user is not in that chat");
            }
            chatDto.UserIds.Remove(userId);
            _db.Chats.Update(_mapper.Map<Chat>(chatDto));

            if(chatDto.UserIds.Count() == 0)
            {
                _db.Chats.Delete(chatId);
            }
            await _db.SaveAsync();
        }

        public async Task<IQueryable<ChatDto>> GetAllChatsAsync()
        {
            var chats = await _db.Chats.GetAllAsync();
            if(chats == null || chats.Count() == 0)
            {
                throw new NotFoundException("Any chat does not exist");
            }
            return _mapper.Map<IQueryable<ChatDto>>(chats);
        }

        public async Task<IQueryable<ChatDto>> GetAllChatsByUserIdAsync(int id)
        {
            var user = await _db.Users.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User does not exist");
            }
            var chats = await _db.Chats.GetAllAsync();
            if (chats == null || chats.Count() == 0)
            {
                throw new NotFoundException("Any chat does not exist");
            }
            var chatsDto = _mapper.Map<IQueryable<ChatDto>>(chats);
            var userChats = chatsDto.Where(chat => chat.UserIds.Contains(id));
            if (userChats == null || userChats.Count() == 0)
            {
                throw new NotFoundException("This user does not have any chat");
            }
            return userChats;
        }

        public async Task<IQueryable<UserDto>> GetAllUsersOfChatAsync(int id)
        {
            var chat = await _db.Chats.GetByIdAsync(id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            var chatDto = _mapper.Map<ChatDto>(chat);
            var users = Enumerable.Empty<UserDto>().AsQueryable();
            foreach (var userId in chatDto.UserIds)
            {
                var user = await _db.Users.GetByIdAsync(userId);
                users.Append(_mapper.Map<UserDto>(user));
            }
            return users;
        }

        public async Task<IQueryable<ChatDto>> GetAllWithDetailsAsync()
        {
            var chats = await _db.Chats.GetAllWithDetailsAsync();
            if (chats == null || chats.Count() == 0)
            {
                throw new NotFoundException("Any chat does not exist");
            }
            return _mapper.Map<IQueryable<ChatDto>>(chats);
        }

        public async Task<ChatDto> GetChatByIdAsync(int id)
        {
            var chat = await _db.Chats.GetByIdAsync(id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<ChatDto> GetChatByIdWithDetailsAsync(int id)
        {
            var chat = await _db.Chats.GetByIdWithDetailsAsync(id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            return _mapper.Map<ChatDto>(chat);
        }

        public async Task RenameChatAsync(ChatDto item)
        {
            var chat = await _db.Chats.GetByIdWithDetailsAsync(item.Id);
            if (chat == null)
            {
                throw new NotFoundException("Chat does not exist");
            }
            if(string.IsNullOrEmpty(item.ChatName))
            {
                throw new NetworkException("Chat name cannot be null or empty");
            }
            chat.ChatName = item.ChatName;
            _db.Chats.Update(chat);
            await _db.SaveAsync();
        }
    }
}

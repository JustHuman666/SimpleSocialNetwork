using Microsoft.EntityFrameworkCore;
using NetworkDAL.Context;
using NetworkDAL.Enteties;
using NetworkDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDAL.Repositories
{
    /// <summary>
    /// Class that represents a chat repository
    /// </summary>
    public class ChatRepository : IChatRepository
    {
        private readonly NetworkContext _context;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public ChatRepository(NetworkContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Chat item)
        {
            await _context.Chats.AddAsync(item);
        }

        public void Delete(int id)
        {
            var chat = _context.Chats.Find(id);
            if(chat != null)
            {
                _context.Chats.Remove(chat);
            }
        }

        public async Task<IQueryable<Chat>> GetAllAsync()
        {
            var chats = await _context.Chats.ToListAsync();
            return chats.AsQueryable();
        }

        public async Task<IQueryable<Chat>> GetAllWithDetailsAsync()
        {
            var chats = await _context.Chats
                .Include(chat => chat.Messages)
                .Include(chat => chat.Users).ToListAsync();
            return chats.AsQueryable();
        }

        public async Task<Chat> GetByIdAsync(int id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task<Chat> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Chats
                .Include(chat => chat.Messages)
                .Include(chat => chat.Users).FirstOrDefaultAsync(chat => chat.Id == id);
        }

        public async Task<IQueryable<Chat>> GetChatsByUserId(int id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            var chats = Enumerable.Empty<Chat>().AsQueryable();
            if(user != null && user.Chats.Count != 0)
            {
                foreach (var userChat in user.Chats)
                {
                    var chat = await _context.Chats.FirstOrDefaultAsync(chat => chat.Id == userChat.ChatId);
                    chats.Append(chat);
                }
            }
            return chats;
        }

        public async Task<IQueryable<UserProfile>> GetUsersOfChatAsync(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            var users = Enumerable.Empty<UserProfile>().AsQueryable();
            if (chat != null && chat.Users.Count != 0)
            {
                foreach (var userChat in chat.Users)
                {
                    var user = await _context.UserProfiles.FirstOrDefaultAsync(us => us.Id == userChat.UserId);
                    users.Append(user);
                }
            }
            return users;
        }

        public void Update(Chat item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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
                .Include(chat => chat.Users).ThenInclude(x => x.User).ToListAsync();
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
                .Include(chat => chat.Users).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(chat => chat.Id == id);
        }

        public void Update(Chat item)
        {
            _context.Entry(item).State = EntityState.Modified;

        }
    }
}

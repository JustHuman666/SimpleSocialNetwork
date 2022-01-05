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
    /// Class that represents a message status repository
    /// </summary>
    class MessageStatusRepository : IMessageStatusRepository
    {
        private readonly NetworkContext _context;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public MessageStatusRepository(NetworkContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<MessageStatus>> GetAllAsync()
        {
            var statuses = await _context.MessageStatuses.ToListAsync();
            return statuses.AsQueryable();
        }

        public async Task<IQueryable<MessageStatus>> GetAllWithDetailsAsync()
        {
            var statuses = await _context.MessageStatuses.Include(status => status.Messages).ToListAsync();
            return statuses.AsQueryable();
        }

        public async Task<MessageStatus> GetByIdAsync(int id)
        {
            return await _context.MessageStatuses.FindAsync(id);
        }

        public async Task<MessageStatus> GetByIdWithDetailsAsync(int id)
        {
            return await _context.MessageStatuses.Include(status => status.Messages).FirstOrDefaultAsync(status => status.Id == id);
        }
    }
}

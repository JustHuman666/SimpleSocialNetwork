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
    /// Class that represents a message repository
    /// </summary>
    public class MessageRepository : IRepository<Message>
    {
        private readonly NetworkContext _context;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public MessageRepository(NetworkContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Message item)
        {
            await _context.Messages.AddAsync(item);
        }

        public void Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if(message != null)
            {
                _context.Messages.Remove(message);
            }
        }

        public async Task<IQueryable<Message>> GetAllAsync()
        { var messages = await _context.Messages.ToListAsync();
            return messages.AsQueryable();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public void UpdateAsync(Message item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}

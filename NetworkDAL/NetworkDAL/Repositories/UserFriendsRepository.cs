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
    public class UserFriendsRepository : IRepository<UserFriends>
    {
        private readonly NetworkContext _context;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public UserFriendsRepository(NetworkContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(UserFriends item)
        {
            await _context.UsersFriends.AddAsync(item);
        }

        public void Delete(int id)
        {
            var friendship = _context.UsersFriends.Find(id);
            if(friendship != null)
            {
                _context.UsersFriends.Remove(friendship);
            }
        }

        public async Task<IQueryable<UserFriends>> GetAllAsync()
        {
            var friends = await _context.UsersFriends.ToListAsync();
            return friends.AsQueryable();
        }

        public async Task<UserFriends> GetByIdAsync(int id)
        {
            return await _context.UsersFriends.FindAsync(id);
        }

        public void Update(UserFriends item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}

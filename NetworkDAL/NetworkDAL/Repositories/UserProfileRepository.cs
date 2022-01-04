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
    /// Class that represents an user profile repository
    /// </summary>
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly NetworkContext _context;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public UserProfileRepository(NetworkContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<UserProfile>> GetAllWithDetailsAsync()
        {
            var userProfiles = await _context.UserProfiles
                .Include(user => user.ThisUserFriends)
                .Include(user => user.UserIsFriend)
                .Include(user => user.Messages)
                .Include(user => user.Chats).ToListAsync();
            return userProfiles.AsQueryable();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<UserProfile> GetByIdWithDetailsAsync(int id)
        {
            return await _context.UserProfiles
                .Include(user => user.ThisUserFriends)
                .Include(user => user.UserIsFriend)
                .Include(user => user.Messages)
                .Include(user => user.Chats).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IQueryable<UserProfile>> GetUserFriendsByIdAsync(int id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            var friends = Enumerable.Empty<UserProfile>().AsQueryable();
            if(user != null && user.ThisUserFriends.Count != 0)
            {
                foreach(var friendId in user.ThisUserFriends)
                {
                    var friend = await _context.UserProfiles.FindAsync(friendId);
                    friends.Append(friend);
                }
            }
            return friends;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NetworkDAL.Context;
using NetworkDAL.Enteties;
using NetworkDAL.Interfaces;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDAL.Repositories
{
    /// <summary>
    /// Class that represents an unit of work with db context and CRUD repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NetworkContext _context;
        private UserProfileRepository _userProfileRepository;
        private MessageRepository _messageRepository;
        private ChatRepository _chatRepository;

        /// <summary>
        /// Constructor for creating of an UOW with given db context, user and role repositories
        /// </summary>
        /// <param name="context">The db context for creating of UOW</param>
        /// <param name="userRepository">The instance of user repository</param>
        /// <param name="roleRepository">The instance of role repository</param>
        public UnitOfWork(NetworkContext context, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _context = context;
            Users = userRepository;
            Roles = roleRepository;
        }

        public IUserRepository Users { get; }

        public IRoleRepository Roles { get; }


        public IUserProfileRepository UsersProfiles 
        {
            get { return _userProfileRepository ??= new UserProfileRepository(_context); }
        }

        public IChatRepository Chats 
        {
            get { return _chatRepository ??= new ChatRepository(_context); }
        }

        public IRepository<Message> Messages 
        {
            get { return _messageRepository ??= new MessageRepository(_context); }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

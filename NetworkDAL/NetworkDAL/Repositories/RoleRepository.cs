using Microsoft.AspNetCore.Identity;
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
    /// Class that represents a role repository
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public RoleRepository(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CheckRoleExistingAsync(string name)
        {
            return await _roleManager.RoleExistsAsync(name);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleManager.Roles;
        }
    }
}

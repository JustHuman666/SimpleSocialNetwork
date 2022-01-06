﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    /// Class that represents an user repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor for creating a repository with given db context
        /// </summary>
        /// <param name="context">The instance of db context for the repository</param>
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddRoleAsync(User item, string role)
        {
            return await _userManager.AddToRoleAsync(item, role);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User item, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(item, oldPassword, newPassword);
        }

        public async Task<bool> CheckPasswordAsync(User item, string password)
        {
            return await _userManager.CheckPasswordAsync(item, password);
        }

        public async Task<IdentityResult> CreateAsync(User item, string password)
        {
            return await _userManager.CreateAsync(item, password);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if(user != null)
            {
               await _userManager.DeleteAsync(user);
            }
        }

        public IQueryable<User> GetAll()
        {
            return _userManager.Users.AsQueryable();
        }


        public async Task<IEnumerable<string>> GetAllUserRoles(User item)
        {
            return await _userManager.GetRolesAsync(item);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await _userManager.Users.Include(user => user.UserProfile).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task UpdateAsync(User item)
        {
            var user = await GetByIdWithDetailsAsync(item.Id);
            if (user != null)
            {
                user.Email = item.Email;
                user.NormalizedEmail = item.Email.ToUpper();
                user.UserName = item.UserName;
                user.NormalizedUserName = item.UserName.ToUpper();
                user.UserProfile.FirstName = item.UserProfile.FirstName;
                user.UserProfile.LastName = item.UserProfile.LastName;
                user.PhoneNumber = item.PhoneNumber;
                user.UserProfile.Country = item.UserProfile.Country;
                user.UserProfile.ThisUserFriends = item.UserProfile.ThisUserFriends;
                user.UserProfile.UserIsFriend = item.UserProfile.UserIsFriend;
            }
        }

    }
}

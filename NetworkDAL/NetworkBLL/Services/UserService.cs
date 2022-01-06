using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkDAL.Enteties;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _db;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork database, IMapper mapper)
        {
            _db = database;
            _mapper = mapper;
        }
        public async Task<UserProfileDto> AddFriend(int userId, int friendId)
        {
            var userProfile = await _db.UsersProfiles.GetByIdWithDetailsAsync(userId);
            var userDto = _mapper.Map<UserProfileDto>(userProfile);
            userDto.ThisUserFriends.Add(friendId, false);
            var user = userProfile.AppUser;
            var userToUpdate = _mapper.Map<User>(user);
            await _db.Users.UpdateAsync(userToUpdate);
            await _db.SaveAsync();
            return userDto;
        }
        public async Task<IQueryable<UserProfileDto>> GetAll()
        {
            var users = await _db.UsersProfiles.GetAllWithDetailsAsync();
            var usersDto = _mapper.Map<IQueryable<UserProfileDto>>(users);
            return usersDto;
        }
        public async Task<IQueryable<UserProfileDto>> GetFriends(int id)
        {
            var friendsProfiles = await _db.UsersProfiles.GetInvitationForFriendshipByIdAsync(id);
            var dtos = _mapper.Map<IQueryable<UserProfileDto>>(friendsProfiles);
            return dtos;
        }
    }
}

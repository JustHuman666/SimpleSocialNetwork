using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;
using NetworkBLL.Validation;
using NetworkDAL.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBLL.Services
{
    /// <summary>
    /// Service for working getting information from user profiles
    /// </summary>
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _db;

        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for creating of service with given unit of work (database and operations) and automapper profile
        /// </summary>
        /// <param name="database">Instance of unit of work for this service</param>
        /// <param name="mapper">Instance of automapper profile</param>
        public UserProfileService(IUnitOfWork database, IMapper mapper)
        {
            _db = database;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserProfileDto>> GetAllProfilesWithDetailsAsync()
        {
            var profiles = await _db.UsersProfiles.GetAllWithDetailsAsync();
            if(profiles == null || profiles.Count() == 0)
            {
                throw new NotFoundException("There is any user profile");
            }
            return _mapper.Map<IQueryable<UserProfileDto>>(profiles);

        }

        public async Task<UserProfileDto> GetProfileByIdAsync(int id)
        {
            var profile = await _db.UsersProfiles.GetByIdAsync(id);
            if (profile == null)
            {
                throw new NotFoundException("User profile does not exist");
            }
            return _mapper.Map<UserProfileDto>(profile);
        }

        public async Task<UserProfileDto> GetProfileByIdWithDetailsAsync(int id)
        {
            var profile = await _db.UsersProfiles.GetByIdWithDetailsAsync(id);
            if (profile == null)
            {
                throw new NotFoundException("User profile does not exist");
            }
            return _mapper.Map<UserProfileDto>(profile); 
        }

        public async Task<IQueryable<UserProfileDto>> GetUserFriendsByIdAsync(int id)
        {
            var profile = await _db.UsersProfiles.GetByIdWithDetailsAsync(id);
            if (profile == null)
            {
                throw new NotFoundException("User profile does not exist");
            }
            if(profile.ThisUserFriends.Count == 0 || profile.ThisUserFriends == null)
            {
                throw new NotFoundException("User has not any friend and invitation");
            }
            var friends = profile.ThisUserFriends.Where(fr => fr.IsConfirmed).Select(friendship => friendship.Friend);
            if(friends.Count() == 0)
            {
                throw new NotFoundException("User has not any confirmed friends");
            }
            return _mapper.Map<IQueryable<UserProfileDto>>(friends);
        }

        public async Task<IQueryable<UserProfileDto>> GetUserInvitationByIdAsync(int id)
        {
            var profile = await _db.UsersProfiles.GetByIdWithDetailsAsync(id);
            if (profile == null)
            {
                throw new NotFoundException("User profile does not exist");
            }
            if (profile.ThisUserFriends.Count == 0 || profile.ThisUserFriends == null)
            {
                throw new NotFoundException("User has not any friend and invitation");
            }
            var friends = profile.ThisUserFriends.Where(fr => !fr.IsConfirmed).Select(friendship => friendship.Friend);
            if (friends.Count() == 0)
            {
                throw new NotFoundException("User has not any unconfirmed friends");
            }
            return _mapper.Map<IQueryable<UserProfileDto>>(friends);
        }
    }
}

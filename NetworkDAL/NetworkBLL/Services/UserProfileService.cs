using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;
using NetworkBLL.Validation;
using NetworkDAL.Enteties;
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

        public async Task<IEnumerable<UserProfileDto>> GetAllProfilesWithDetailsAsync()
        {
            var profiles = await _db.UsersProfiles.GetAllWithDetailsAsync();
            if(profiles == null || profiles.Count() == 0)
            {
                throw new NotFoundException("There is any user profile");
            }
            return _mapper.Map<IEnumerable<UserProfileDto>>(profiles);

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

        public async Task<IEnumerable<UserProfileDto>> GetUserFriendsByIdAsync(int id)
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
            var friends = new List<UserProfile>();
            foreach (var friendship in profile.ThisUserFriends)
            {
                if (friendship.IsConfirmed)
                {
                    var friend = await _db.UsersProfiles.GetByIdWithDetailsAsync(friendship.FriendId.Value);
                    friends.Add(friend);
                }
            }
            if(friends.Count() == 0)
            {
                throw new NotFoundException("User has not any confirmed friends");
            }
            return _mapper.Map<IEnumerable<UserProfileDto>>(friends);
        }

        public async Task<IEnumerable<UserProfileDto>> GetUserInvitationByIdAsync(int id)
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
            var friends = new List<UserProfile>();
            foreach (var friendship in profile.ThisUserFriends)
            {
                if (!friendship.IsConfirmed)
                {
                    var friend = await _db.UsersProfiles.GetByIdWithDetailsAsync(friendship.FriendId.Value);
                    friends.Add(friend);
                }
            }
            if (friends.Count() == 0)
            {
                throw new NotFoundException("User has not any invitations");
            }
            return _mapper.Map<IEnumerable<UserProfileDto>>(friends);
        }

        public async Task SendInvitationForFriendshipAsync(int userId, int wantedFriendId)
        {
            var user = await _db.Users.GetByIdWithDetailsAsync(userId);
            var friend = await _db.Users.GetByIdWithDetailsAsync(wantedFriendId);
            if (user == null || friend == null)
            {
                throw new NotFoundException("User does not exist");
            }
            var friendship = friend.UserProfile.ThisUserFriends.FirstOrDefault(fr => fr.FriendId == wantedFriendId);
            if (friendship != null)
            {
                throw new NetworkException("Such invitation for friendship already exist");
            }
            var userDto = _mapper.Map<UserDto>(user);
            var friendDto = _mapper.Map<UserDto>(friend);
            friendDto.UserProfile.ThisUserFriendIds.Add(userId);

            await _db.Users.UpdateAsync(_mapper.Map<User>(userDto));
            await _db.Users.UpdateAsync(_mapper.Map<User>(friendDto));
            await _db.SaveAsync();
        }

        public async Task ConfirmFriendsip(int userId, int friendToConfirmId)
        {
            var user = await _db.Users.GetByIdWithDetailsAsync(userId);
            var friend = await _db.Users.GetByIdWithDetailsAsync(friendToConfirmId);
            if (user == null || friend == null)
            {
                throw new NotFoundException("User does not exist");
            }

            var friendship = user.UserProfile.ThisUserFriends.FirstOrDefault(fr => fr.FriendId == friendToConfirmId);
            if (friendship == null)
            {
                throw new NotFoundException("Such invitation for friendship does not exist");
            }
            if (friendship.IsConfirmed)
            {
                throw new NetworkException("This friendship is already confirmed");
            }
            friendship.IsConfirmed = true;

            friend.UserProfile.ThisUserFriends.Add(new UserFriends() { UserId = friend.Id, FriendId = user.Id, IsConfirmed = true });
            
            await _db.Users.UpdateAsync(user);
            await _db.Users.UpdateAsync(friend);

            await _db.SaveAsync();
        }


        public async Task DeleteFriendByFriendId(int userId, int friendToDeleteId)
        {
            var user = await _db.Users.GetByIdWithDetailsAsync(userId);
            var friend = await _db.Users.GetByIdWithDetailsAsync(friendToDeleteId);
            if (user == null || friend == null)
            {
                throw new NotFoundException("User does not exist");
            }
            var friendship = user.UserProfile.ThisUserFriends.FirstOrDefault(fr => fr.FriendId == friendToDeleteId);
            if (friendship == null)
            {
                throw new NotFoundException("Such invitation for friendship does not exist");
            }
            var invitation = user.UserProfile.UserIsFriend.FirstOrDefault(fr => fr.UserId == friendToDeleteId);
            if (invitation != null)
            {
                user.UserProfile.UserIsFriend.Remove(invitation);
            }
            user.UserProfile.ThisUserFriends.Remove(friendship);

            var friendshipSecond = friend.UserProfile.ThisUserFriends.FirstOrDefault(fr => fr.FriendId == userId);
            if (friendshipSecond == null)
            {
                throw new NotFoundException("Such invitation for friendship does not exist");
            }
            var invitationSecond = friend.UserProfile.UserIsFriend.FirstOrDefault(fr => fr.UserId == userId);
            if (invitationSecond != null)
            {
                friend.UserProfile.UserIsFriend.Remove(invitationSecond);
            }
            friend.UserProfile.ThisUserFriends.Remove(friendshipSecond);

            await _db.Users.UpdateAsync(user);
            await _db.Users.UpdateAsync(friend);
            await _db.SaveAsync();
        }

        public async Task<IEnumerable<UserProfileDto>> GetAllInvitationsWhichUSerSentById(int userId)
        {
            var profile = await _db.UsersProfiles.GetByIdWithDetailsAsync(userId);
            if (profile == null)
            {
                throw new NotFoundException("User profile does not exist");
            }
            if (profile.UserIsFriend.Count == 0 || profile.UserIsFriend == null)
            {
                throw new NotFoundException("User has not any friend and invitation");
            }
            var invitations = new List<UserProfile>();
            foreach (var invitation in profile.UserIsFriend)
            {
                if (!invitation.IsConfirmed)
                {
                    var invited = await _db.UsersProfiles.GetByIdWithDetailsAsync(invitation.UserId.Value);
                    invitations.Add(invited);
                }
            }
            if (invitations.Count() == 0)
            {
                throw new NotFoundException("User has not any invitations");
            }
            return _mapper.Map<IEnumerable<UserProfileDto>>(invitations);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkAPI.Models;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;

namespace NetworkAPI.Controllers
{
    /// <summary>
    /// Controller for working for friends of user etc
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for creating of controller with given services and mapper profile
        /// </summary>
        /// <param name="mapper">Auto mapper profile for models and dtos</param>
        /// <param name="userProfileService">User profile service</param>
        public FriendController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        /// <summary>
        /// To get user friends by its id allowed for all registered users
        /// </summary>
        /// <param name="id">The id of user whose friends should be found</param>
        /// <returns>Found user collection of friends</returns>
        [HttpGet]
        [Route("UserFriends/{id}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetUserFriendsById(int id)
        {
            var friends = await _userProfileService.GetUserFriendsByIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(friends));
        }

        /// <summary>
        /// To get own user friends by himself
        /// </summary>
        /// <returns>Found user collection of friends</returns>
        [HttpGet]
        [Route("OwnFriends")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetUserOwnFriendsById()
        {
            var friends = await _userProfileService.GetUserFriendsByIdAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(friends));
        }

        /// <summary>
        /// To get own user invitations to be friends
        /// </summary>
        /// <returns>Found user collection of invitations</returns>
        [HttpGet]
        [Route("GetOwnInvitations")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetUserOwnInvitationsById()
        {
            var friends = await _userProfileService.GetUserInvitationByIdAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(friends));
        }

        /// <summary>
        /// To get invitations sent by this user
        /// </summary>
        /// <returns>Found user collection of invitations</returns>
        [HttpGet]
        [Route("GetSentInvitations")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult<IEnumerable<UserProfileModel>>> GetInvitationsByUserById()
        {
            var friends = await _userProfileService.GetAllInvitationsWhichUSerSentById(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(_mapper.Map<IEnumerable<UserProfileModel>>(friends));
        }

        /// <summary>
        /// To confirm friendship with chosen user
        /// </summary>
        /// <param name="friendId">The id of user whose invitation to be a friend should be confirmed</param>
        /// <returns>Result status code</returns>
        [HttpPut]
        [Route("Confirm/{friendId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> ConfirmFriendshipWithUser(int friendId)
        {
            await _userProfileService.ConfirmFriendsip(
                Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value), friendId);
            return Ok();
        }

        /// <summary>
        /// To stop friendship with chosen user
        /// </summary>
        /// <param name="friendId">The id of user who should be deleted from user friends</param>
        /// <returns>Result status code</returns>
        [HttpDelete]
        [Route("{friendId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> DeleteUserFromFriends(int friendId)
        {
            await _userProfileService.DeleteFriendByFriendId(
                Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value), friendId);
            return Ok();
        }

        /// <summary>
        /// To send an invitation to be friends to a chosen user 
        /// </summary>
        /// <param name="friendId">The id of user who is wanted to de a friend with sender</param>
        /// <returns>Result status code</returns>
        [HttpPost]
        [Route("Invite/{friendId}")]
        [Authorize(Roles = "Registered")]
        public async Task<ActionResult> SendInvitationForFriendship(int friendId)
        {
            await _userProfileService.SendInvitationForFriendshipAsync(
                Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value), friendId);
            return Ok();
        }
    }
}
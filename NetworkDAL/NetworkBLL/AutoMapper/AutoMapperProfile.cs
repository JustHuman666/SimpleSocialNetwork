using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkDAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkBLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserDto>()
                .ForMember(p => p.FirstName, c => c.MapFrom(src => src.UserProfile.FirstName))
                .ForMember(p => p.LastName, c => c.MapFrom(src => src.UserProfile.LastName))
                .ForMember(p => p.LastName, c => c.MapFrom(src => src.UserProfile.Country))
                .ReverseMap();

            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(p => p.Email, c => c.MapFrom(src => src.AppUser.Email))
                .ForMember(p => p.PhoneNumber, c => c.MapFrom(src => src.AppUser.PhoneNumber))
                .ForMember(p => p.UserName, c => c.MapFrom(src => src.AppUser.UserName))
                .ForMember(p => p.MessageIds, c => c.MapFrom(src => src.Messages.Select(item => item.Id)))
                .ForMember(p => p.ChatIds, c => c.MapFrom(src => src.Chats.Select(item => item.ChatId)))
                .ForMember(p => p.ThisUserFriends, c => c.MapFrom(src => src.ThisUserFriends.ToDictionary(key => key.FriendId, value => value.IsConfirmed)))
                .ForMember(p => p.UserTheirFriend, c => c.MapFrom(src => src.UserIsFriend.ToDictionary(key => key.UserId, value => value.IsConfirmed)))
                .ReverseMap();
            //.ForMember(p => p.ThisUserFriendIds, c => c.MapFrom(src => src.ThisUserFriends.Select(item => item.FriendId)))
            //.ForMember(p => p.UserIsFriendIds, c => c.MapFrom(src => src.UserIsFriend.Select(item => item.UserId)))

            CreateMap<UserProfileDto, UserDto>().ReverseMap();

            CreateMap<MessageStatus, MessageStatusDto>()
                .ForMember(p => p.MessageIds, c => c.MapFrom(src => src.Messages.Select(item => item.Id)))
                .ReverseMap();

            CreateMap<Message, MessageDto>().ReverseMap();

            CreateMap<Chat, ChatDto>()
                .ForMember(p => p.MessageIds, c => c.MapFrom(src => src.Messages.Select(item => item.Id)))
                .ForMember(p => p.UserIds, c => c.MapFrom(src => src.Users.Select(item => item.UserId)))
                .ReverseMap();
        }

    }
}

using AutoMapper;
using NetworkBLL.EntetiesDto;
using NetworkDAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkBLL.AutoMapper
{
    /// <summary>
    /// Auto mapper profile for all dtos and enteties
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserDto>()
                .ForMember(p => p.FirstName, c => c.MapFrom(src => src.UserProfile.FirstName))
                .ForMember(p => p.LastName, c => c.MapFrom(src => src.UserProfile.LastName))
                .ReverseMap();

            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(p => p.Email, c => c.MapFrom(src => src.AppUser.Email))
                .ForMember(p => p.PhoneNumber, c => c.MapFrom(src => src.AppUser.PhoneNumber))
                .ForMember(p => p.UserName, c => c.MapFrom(src => src.AppUser.UserName))
                .ForMember(p => p.MessageIds, c => c.MapFrom(src => src.Messages.Select(item => item.Id)))
                .ForMember(p => p.ChatIds, c => c.MapFrom(src => src.Chats.Select(item => item.ChatId)))
                .ForMember(p => p.ThisUserFriendIds, c => c.MapFrom(src => src.ThisUserFriends.Select(item => item.FriendId)))
                .ForMember(p => p.UserIsFriendIds, c => c.MapFrom(src => src.UserIsFriend.Select(item => item.FriendId)));

            CreateMap<UserProfileDto, UserProfile>()
                .ForPath(p => p.AppUser.Email, c => c.MapFrom(src => src.Email))
                .ForPath(p => p.AppUser.PhoneNumber, c => c.MapFrom(src => src.PhoneNumber))
                .ForPath(p => p.AppUser.UserName, c => c.MapFrom(src => src.UserName))
                .ForMember(p => p.Messages, c => c.MapFrom(src => src.MessageIds))
                .ForMember(p => p.Chats, c => c.MapFrom(src => src.ChatIds))
                .ForMember(p => p.ThisUserFriends, c => c.MapFrom(src => src.ThisUserFriendIds))
                .ForMember(p => p.UserIsFriend, c => c.MapFrom(src => src.UserIsFriendIds));

            CreateMap<UserProfileDto, UserDto>().ReverseMap();

            CreateMap<Message, MessageDto>().ReverseMap();

            CreateMap<Chat, ChatDto>()
                .ForMember(p => p.MessageIds, c => c.MapFrom(src => src.Messages.Select(item => item.Id)))
                .ForMember(p => p.UserIds, c => c.MapFrom(src => src.Users.Select(item => item.UserId)));

            CreateMap<ChatDto, Chat>()
                .ForMember(p => p.Messages, c => c.MapFrom(src => src.MessageIds))
                .ForMember(p => p.Users, c => c.MapFrom(src => src.UserIds));

            CreateMap<int, UserChat>()
                .ForMember(dest => dest.UserId, m => m.MapFrom(src => src));

            CreateMap<int, UserFriends>()
                .ForMember(dest => dest.FriendId, m => m.MapFrom(src => src));

            CreateMap<int, Message>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src));
        }

    }
}

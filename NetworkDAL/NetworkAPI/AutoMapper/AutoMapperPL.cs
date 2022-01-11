using AutoMapper;
using NetworkAPI.Models;
using NetworkBLL.EntetiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAPI.AutoMapper
{
    /// <summary>
    /// Auto mapper profile for all dtos and models
    /// </summary>
    public class AutoMapperPL : Profile
    {
        public AutoMapperPL()
        {
            CreateMap<UserProfileDto, UserProfileModel>()
                .ForMember(p => p.ThisUserFriendIds, c => c.MapFrom(src => src.ThisUserFriendIds))
                .ReverseMap();

            CreateMap<UserDto, UserModel>().ReverseMap();

            CreateMap<UserDto, RegisterModel>().ReverseMap();

            CreateMap<MessageDto, MessageModel>().ReverseMap();

            CreateMap<ChatDto, ChatModel>()
                .ForMember(p => p.UserIds, c => c.MapFrom(src => src.UserIds))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.TweetDto;
using com.tweetapp.Models.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Mapper
{
    public class UserDataMapper : Profile
    {
        public UserDataMapper()
        {
            CreateMap<CreateUserDto, Users>().ReverseMap();
            CreateMap<ViewUserDto, Users>().ReverseMap();
            CreateMap<ViewUserDto, CreateUserDto>().ReverseMap();

            CreateMap<CreateTweetDto, Tweets>();
            
        }
    }
}

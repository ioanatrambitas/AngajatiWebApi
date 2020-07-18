﻿using AutoMapper;

namespace AngajatiWebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, ExternalModels.UserDTO>();
            CreateMap<ExternalModels.UserDTO, Entities.User>();
        }
    }
}

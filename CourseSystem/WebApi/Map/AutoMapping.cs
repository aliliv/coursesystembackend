using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Core.Entities.Concrate;

namespace WebApi.Map
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDto>();
        }
    }
}

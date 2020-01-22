using AutoMapper;
using Business.Mediatr.Users.Commands.CreateUser;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    public class AutoMapperHelper:Profile   
    {
        public AutoMapperHelper()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}

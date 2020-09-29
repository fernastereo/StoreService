using AutoMapper;
using ServiceStore.Api.Author.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorDto>();
        }
    }
}

using AutoMapper;
using ServiceStore.Api.Book.Application;
using ServiceStore.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStore.Api.Book.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<BookAuthor, BookAuthorDto>();
        }
    }
}

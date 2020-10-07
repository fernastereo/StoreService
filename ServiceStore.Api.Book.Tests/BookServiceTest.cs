using AutoMapper;
using Moq;
using ServiceStore.Api.Book.Application;
using ServiceStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceStore.Api.Book.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void GetBooks()
        {
            //Which method of the microervice is in charge of query books?

            //1. Emulate EFCore instance: BookContext
            //To emulate the actions and events from an object in unit test environment que need to use a Mock object
            //install: Moq package

            var mockContext = new Mock<BookContext>();

            //2. Emulate IMapper
            var mockMapper = new Mock<IMapper>();

            //3. Instanciate the Handler class and send as parameters the created mocks before
            Query.Handler handler = new Query.Handler(mockContext.Object, mockMapper.Object);
        }
    }
}

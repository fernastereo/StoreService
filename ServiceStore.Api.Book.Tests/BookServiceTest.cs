using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceStore.Api.Book.Application;
using ServiceStore.Api.Book.Model;
using ServiceStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ServiceStore.Api.Book.Tests
{
    public class BookServiceTest
    {
        private IEnumerable<BookAuthor> GetDataTest()
        {
            A.Configure<BookAuthor>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.BookId, () => { return Guid.NewGuid(); });

            var list = A.ListOf<BookAuthor>(30);
            list[0].BookId = Guid.Empty;

            return list;
        }

        private Mock<BookContext> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();
            
            var dbSet = new Mock<DbSet<BookAuthor>>();
            dbSet.As<IQueryable<BookAuthor>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<BookAuthor>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<BookAuthor>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<BookAuthor>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BookAuthor>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
            .Returns(new AsyncEnumerator<BookAuthor>(dataTest.GetEnumerator()));

            var context = new Mock<BookContext>();
            context.Setup(x => x.Book).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetBooks()
        {
            System.Diagnostics.Debugger.Launch();
            //Which method of the microervice is in charge of query books?

            //1. Emulate EFCore instance: BookContext
            //To emulate the actions and events from an object in unit test environment que need to use a Mock object
            //install: Moq package

            var mockContext = CreateContext();

            //2. Emulate IMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            //3. Instanciate the Handler class and send as parameters the created mocks before
            Query.Handler handler = new Query.Handler(mockContext.Object, mapper);

            Query.Execute request = new Query.Execute();

            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());
        }
    }
}

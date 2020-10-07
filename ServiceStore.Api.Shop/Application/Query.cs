using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ServiceStore.Api.Shop.Persistence;
using ServiceStore.Api.Shop.RemoteInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Application
{
    public class Query
    {
        public class Execute : IRequest<ShopDto>
        {
            public int ShopSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, ShopDto>
        {
            private readonly ShopContext _context;
            private readonly IBooksService _bookService;

            public Handler(ShopContext context, IBooksService bookService)
            {
                _context = context;
                _bookService = bookService;
            }
            public async Task<ShopDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shopSession = await _context.ShopSession.FirstOrDefaultAsync(x => x.ShopSessionId == request.ShopSessionId);
                var shopSessionDetail = await _context.ShopSessionDetail.Where(x => x.ShopSessionId == request.ShopSessionId).ToListAsync();
                
                var listShopDto = new List<ShopDetailDto>();
                
                foreach (var book in shopSessionDetail)
                {
                    var response = await _bookService.GetBook(new Guid(book.SelectedProduct));
                    if (response.result)
                    {
                        var bookResponse = response.Book;
                        var shopDetail = new ShopDetailDto
                        {
                            BookTitle = bookResponse.Title,
                            ReleaseDate = bookResponse.ReleaseDate,
                            BookId = bookResponse.BookId
                        };
                        listShopDto.Add(shopDetail);
                    }
                }

                var shopSessionDto = new ShopDto
                {
                    ShopId = shopSession.ShopSessionId,
                    SessionCreatedAt = shopSession.CreatedAt,
                    ProductList = listShopDto
                };

                return shopSessionDto;
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Book.Model;
using ServiceStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Book.Application
{
    public class QueryFiltered
    {
        public class UniqueBook : IRequest<BookAuthorDto>
        {
            public Guid? BookId { get; set; }
        }

        public class Handler : IRequestHandler<UniqueBook, BookAuthorDto>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookAuthorDto> Handle(UniqueBook request, CancellationToken cancellationToken)
            {
                var book = await _context.Book.Where(x => x.BookId == request.BookId).FirstOrDefaultAsync();
                if (book == null)
                {
                    throw new Exception("Book not found!");
                }
                var bookDto = _mapper.Map<BookAuthor, BookAuthorDto>(book);
                return bookDto;
            }
        }
    }
}

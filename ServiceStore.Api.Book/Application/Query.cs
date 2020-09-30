using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Book.Model;
using ServiceStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Book.Application
{
    public class Query
    {
        public class Execute : IRequest<List<BookAuthorDto>>
        {

        }

        public class Handler : IRequestHandler<Execute, List<BookAuthorDto>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BookAuthorDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.Book.ToListAsync();
                var booksDto = _mapper.Map<List<BookAuthor>, List<BookAuthorDto>>(books);
            }
        }
    }
}

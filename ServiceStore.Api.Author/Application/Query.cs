using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Model;
using ServiceStore.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorBook>>
        {

        }

        public class Handler : IRequestHandler<AuthorList, List<AuthorBook>>
        {
            private readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                _context = context;
            }
            public async Task<List<AuthorBook>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.AuthorBook.ToListAsync();

                return authors;
            }
        }
    }
}

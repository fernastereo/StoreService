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
    public class QueryFiltered
    {
        public class UniqueAuthor : IRequest<AuthorBook>
        {
            public string AuthorBookGuid { get; set; }
        }

        //Clase de la que recibo los parametros y lo que voy a devolver
        public class Handler : IRequestHandler<UniqueAuthor, AuthorBook>
        {
            private readonly AuthorContext _context;
            public Handler(AuthorContext context)
            {
                _context = context;
            }
            public async Task<AuthorBook> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBook.Where(x => x.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("Author not found!");
                }

                return author;
            }
        }
    }
}

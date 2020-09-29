using AutoMapper;
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
        public class UniqueAuthor : IRequest<AuthorDto>
        {
            public string AuthorBookGuid { get; set; }
        }

        //Clase de la que recibo los parametros y lo que voy a devolver
        public class Handler : IRequestHandler<UniqueAuthor, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBook.Where(x => x.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("Author not found!");
                }
                var authorDto = _mapper.Map<AuthorBook, AuthorDto>(author);

                return authorDto;
            }
        }
    }
}

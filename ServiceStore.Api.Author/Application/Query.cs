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
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>>
        {

        }

        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.AuthorBook.ToListAsync();
                //El formato que entra/El formato que sale/la data que se va a transformar:
                var authorsDto = _mapper.Map<List<AuthorBook>, List<AuthorDto>>(authors);
                return authorsDto;
            }
        }
    }
}

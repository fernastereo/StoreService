using FluentValidation;
using MediatR;
using ServiceStore.Api.Book.Model;
using ServiceStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Titulo { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public Guid? AuthorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.ReleaseDate).NotEmpty();
                RuleFor(x => x.AuthorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly BookContext _context;

            public Handler(BookContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new BookAuthor
                {
                    Title = request.Titulo,
                    ReleaseDate = request.ReleaseDate,
                    AuthorBook = request.AuthorBook
                };

                _context.Book.Add(book);

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Book could not be stored");
            }
        }
    }
}

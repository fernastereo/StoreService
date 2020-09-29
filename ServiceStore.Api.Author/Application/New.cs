using FluentValidation;
using MediatR;
using ServiceStore.Api.Author.Migrations;
using ServiceStore.Api.Author.Model;
using ServiceStore.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var authorBook = new AuthorBook
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    AuthorBookGuid = Convert.ToString(Guid.NewGuid())
                };

                _context.AuthorBook.Add(authorBook);
                var result = await _context.SaveChangesAsync();

                if (result>0)
                {
                    return Unit.Value;
                }

                throw new Exception("Author's book could not be stored");
            }
        }
    }
}

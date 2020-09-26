using MediatR;
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

        public class Handler : IRequestHandler<Execute>
        {
            public Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

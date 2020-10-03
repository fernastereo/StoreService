using MediatR;
using ServiceStore.Api.Shop.Model;
using ServiceStore.Api.Shop.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime CreatedAt { get; set; }
            public List<string> DetailList { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ShopContext _context;

            public Handler(ShopContext context)
            {
                _context = context;
            }
            public async  Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shopSession = new ShopSession
                {
                    CreatedAt = request.CreatedAt
                };
                _context.ShopSession.Add(shopSession);
                var value = await _context.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("There was an error on shop session");
                }

                int id = shopSession.ShopSessionId;
                foreach (var obj in request.DetailList)
                {
                    var sessionDetail = new ShopSessionDetail
                    {
                        CreatedAt = DateTime.Now,
                        ShopSessionId = id,
                        SelectedProduct = obj
                    };

                    _context.ShopSessionDetail.Add(sessionDetail);
                }

                value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Products detail could not be saved");

            }
        }
    }
}

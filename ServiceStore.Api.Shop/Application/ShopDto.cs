using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Application
{
    public class ShopDto
    {
        public int ShopId { get; set; }
        public DateTime? SessionCreatedAt { get; set; }
        public List<ShopDetailDto> ProductList { get; set; }
    }
}

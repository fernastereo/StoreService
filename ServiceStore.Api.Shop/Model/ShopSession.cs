using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Model
{
    public class ShopSession
    {
        public int ShopSessionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<ShopSessionDetail> DetailList { get; set; }
    }
}

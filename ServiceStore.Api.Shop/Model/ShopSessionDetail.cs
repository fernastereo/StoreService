using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Model
{
    public class ShopSessionDetail
    {
        public int ShopSessionDetailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SelectedProduct { get; set; }
        public int ShopSessionId { get; set; }
        public ShopSession ShopSession { get; set; }
    }
}

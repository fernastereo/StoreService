using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Application
{
    public class ShopDetailDto
    {
        public Guid? BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorBook { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}

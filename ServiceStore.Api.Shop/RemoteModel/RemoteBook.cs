using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.RemoteModel
{
    public class RemoteBook
    {
        public int BookAuthorId { get; set; }
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}

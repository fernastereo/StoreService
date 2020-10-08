using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Book.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext()
        {

        }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
                
        }

        public virtual DbSet<BookAuthor> Book { get; set; }
    }
}

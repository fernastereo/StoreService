using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Persistence
{
    public class AuthorContext: DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options): base(options)
        {

        }

        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<AcademicGrade> AcademicGrade { get; set; }
    }
}

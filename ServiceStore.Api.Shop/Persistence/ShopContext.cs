using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.Persistence
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base (options)
        {

        }

        public DbSet<ShopSession> ShopSession { get; set; }
        public DbSet<ShopSessionDetail> ShopSessionDetail { get; set; }
    }
}

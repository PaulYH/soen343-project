using Microsoft.EntityFrameworkCore;
using SHC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSHS.Database
{
    public class SHSDbContext : DbContext
    {
        public SHSDbContext(DbContextOptions<SHSDbContext> options) : base(options) { }

        public DbSet<VirtualUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

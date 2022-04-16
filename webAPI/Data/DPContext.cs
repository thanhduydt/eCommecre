using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Model;

namespace webAPI.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}

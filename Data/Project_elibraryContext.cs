using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_elibrary.Models;

namespace Project_elibrary.Data
{
    public class Project_elibraryContext : DbContext
    {
        public Project_elibraryContext (DbContextOptions<Project_elibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Project_elibrary.Models.Product> Product { get; set; } = default!;

        public DbSet<Project_elibrary.Models.Supplier>? Supplier { get; set; }
    }
}

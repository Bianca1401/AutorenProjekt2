using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutorenProjekt2.Models;

namespace AutorenProjekt2.Data
{
    public class AutorenProjekt2Context : DbContext
    {
        public AutorenProjekt2Context (DbContextOptions<AutorenProjekt2Context> options)
            : base(options)
        {
        }

        public DbSet<AutorenProjekt2.Models.Buch> Buch { get; set; } = default!;
        public DbSet<AutorenProjekt2.Models.Rezension> Rezension { get; set; } = default!;
    }
}

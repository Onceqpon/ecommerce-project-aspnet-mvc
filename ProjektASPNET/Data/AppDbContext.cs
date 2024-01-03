﻿using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}

﻿using Api_Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Intro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }


    }
}
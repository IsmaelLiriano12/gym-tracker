using GymTrackerShared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Data
{
    public class GymTrackerDbContext : IdentityDbContext<IdentityUser>
    {

        private readonly IConfiguration _config;

        public GymTrackerDbContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ProgressiveOverload> ProgressiveOverloads { get; set; }
        public DbSet<ProfileData> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlServer(_config.GetConnectionString("GymTrackerDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Weight)
                .HasPrecision(5, 1);
        }
    }
}
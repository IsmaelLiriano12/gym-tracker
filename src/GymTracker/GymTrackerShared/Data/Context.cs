using GymTrackerShared.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ProgressiveOverload> ProgressiveOverloads { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Weight)
                .HasPrecision(5, 1);
        }
    }
}
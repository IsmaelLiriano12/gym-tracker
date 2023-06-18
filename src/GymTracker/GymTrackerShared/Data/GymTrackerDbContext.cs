using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Data
{
    public class GymTrackerDbContext : IdentityDbContext<IdentityUser>
    {
        public GymTrackerDbContext()
            : base("GymTrackerDbContext")
        {

        }

        public DbSet<Routine> Routines { get; set; }
        public DbSet<ExerciseStats> Exercises { get; set; }
        public DbSet<ProgressiveOverload> ProgressiveOverloads { get; set; }
        public DbSet<AccountData> Accounts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Entity<ExerciseStats>()
                .Property(e => e.Weight)
                .HasPrecision(5, 1);

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Amount)
                .HasPrecision(4, 1);

            
        }
    }
}
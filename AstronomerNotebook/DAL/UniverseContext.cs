using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AstronomerNotebook.Models;

namespace AstronomerNotebook.DAL
{
    public class UniverseContext : DbContext
    {
        public UniverseContext() : base("DefaultConnection")
        {

        }

        public DbSet<Star> Stars { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Galaxy> Galaxies { get; set; }
        public DbSet<Astronomer> Astronomers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tuningteile.Models;

namespace Tuningteile.Data
{
    public class TuningteileContext : DbContext
    {
        public TuningteileContext (DbContextOptions<TuningteileContext> options)
            : base(options)
        {
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TuningPart> TuningPart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<manufacturer> manufacturer { get; set; }
        public DbSet<compatibility> compatibility { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();

            //Table for the part compatibility with a model
            modelBuilder.Entity<compatibility>()
                .HasKey(x => new { x.TuningPartId, x.ModelID });

            modelBuilder.Entity<compatibility>()
                .HasOne(T => T.TuningPart)
                .WithMany(co => co.compatibilities)
                .HasForeignKey(co => co.TuningPartId);

            modelBuilder.Entity<compatibility>()
                .HasOne(T => T.Model)
                .WithMany(co => co.compatibilities)
                .HasForeignKey(co => co.ModelID);

            
        }
        

       
    }
}

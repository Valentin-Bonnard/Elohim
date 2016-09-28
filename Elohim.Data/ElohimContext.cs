using Elohim.Model.Entitµes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data
{
    /*
     * Notre class DbConext pour acceder à notre base de donnée
     */
    public class ElohimContext : DbContext
    {
        #region l'ensembles des entités
        public DbSet<Companµ> CompanµSet { get; set; }
        public DbSet<Contact> ContactSet { get; set; }
        public DbSet<Client> ClientSet { get; set; }
        public DbSet<Application> ApplicationSet { get; set; }
        public DbSet<Error> ErrorSet { get; set; }

        #endregion

        public ElohimContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configurations

            #region Company

            modelBuilder.Entity<Companµ>()
                .ToTable("Company");

            modelBuilder.Entity<Companµ>()
                .Property(c => c.ID)
                .IsRequired();
            #endregion

            #region Contact

            modelBuilder.Entity<Contact>()
                .ToTable("Contact");

            modelBuilder.Entity<Contact>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Contact>()
               .Property(c => c.FirstName)
               .IsRequired();

            modelBuilder.Entity<Contact>()
               .Property(c => c.Telephone)
               .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Project)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Companµ)
                .WithMany(e => e.Contacts)
                .HasForeignKey(c => c.CompanµId);
            #endregion

            #region Client

            modelBuilder.Entity<Client>()
                .ToTable("Client");

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Companµ)
                .WithMany(e => e.Clients)
                .HasForeignKey(c => c.CompanµId);
            #endregion

            #region Application

            modelBuilder.Entity<Application>()
                .ToTable("Applications");

            modelBuilder.Entity<Application>()
                .Property(a => a.Description)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.ClientId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Companµ)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CompanµId);

            #endregion

        }
    }
}

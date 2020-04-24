using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeltaEndpoint.Models
{
    public partial class deltastoreContext : DbContext
    {
        public deltastoreContext()
        {
        }

        public deltastoreContext(DbContextOptions<deltastoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incident> Incident { get; set; }

        public virtual DbSet<Location> Locations {get; set;}

        public virtual  DbSet<IssueType> IssueType {get;set;}
        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = GetConnectionString();
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.Property(e => e.IncidentId).ValueGeneratedNever();

                entity.Property(e => e.CreatorContact);
                   

                entity.Property(e => e.IssueType)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Media).HasColumnType("image");
            });

            modelBuilder.Entity<Location>(loc=>
            {
                loc.Property(e => e.LocationId).ValueGeneratedNever();

                loc.Property(e => e.LocationName)
                .HasMaxLength(300)
                .IsUnicode(false);
            });

            modelBuilder.Entity<IssueType>(issue=>
            {
                issue.Property(e => e.IssueTypeId).ValueGeneratedNever();

                issue.Property(e => e.IssueTypeName)
                .HasMaxLength(200)
                .IsUnicode(false);
            });
        }
    }
}


using IOT_API2.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IOT_API2.Database
{
    public class AppDBContext : DbContext
    {

        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<UserGroup>().ToTable("UserGroups");
            modelBuilder.Entity<AppUser>().ToTable("Users");

            // Configure Primary Keys  
            modelBuilder.Entity<UserGroup>().HasKey(ug => ug.Id).HasName("PK_UserGroups");
            modelBuilder.Entity<AppUser>().HasKey(u => u.Id).HasName("PK_Users");

            // Configure indexes  
            modelBuilder.Entity<UserGroup>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<AppUser>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<AppUser>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");

            // Configure columns  
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Id).HasColumnType("int").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<AppUser>().Property(u => u.Id).HasColumnType("int").IsRequired();
            modelBuilder.Entity<AppUser>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<AppUser>().Property(u => u.LastName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<AppUser>().Property(u => u.UserGroupId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<AppUser>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<AppUser>().Property(u => u.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            // Configure relationships  
            modelBuilder.Entity<AppUser>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }
    }
}

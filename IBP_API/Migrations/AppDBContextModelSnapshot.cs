﻿// <auto-generated />
using System;
using IOT_API2.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IOT_API2.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("IOT_API2.Database.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Mobile")
                        .HasColumnType("longtext");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.HasIndex("FirstName")
                        .HasDatabaseName("Idx_FirstName");

                    b.HasIndex("LastName")
                        .HasDatabaseName("Idx_LastName");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IOT_API2.Database.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_UserGroups");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Idx_Name");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("IOT_API2.Database.Models.AppUser", b =>
                {
                    b.HasOne("IOT_API2.Database.Models.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .HasConstraintName("FK_Users_UserGroups")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
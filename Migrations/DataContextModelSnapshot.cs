﻿// <auto-generated />
using System;
using Fanap.Plus.Product_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fanap.Plus.Product_Management.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.Members", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Role");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TeamId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ProductManagementName");

                    b.Property<string>("ProductOwnerName");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.TeamAssignment", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("ProductId");

                    b.HasKey("TeamId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("TeamAssignment");
                });

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.Members", b =>
                {
                    b.HasOne("Fanap.Plus.Product_Management.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Fanap.Plus.Product_Management.Models.Teams", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Fanap.Plus.Product_Management.Models.TeamAssignment", b =>
                {
                    b.HasOne("Fanap.Plus.Product_Management.Models.Products", "Product")
                        .WithMany("TeamAssignments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fanap.Plus.Product_Management.Models.Teams", "Team")
                        .WithMany("TeamAssignments")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

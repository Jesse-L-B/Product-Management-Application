﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductManagementSystem.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Wooden Training Sword",
                            ImageName = "woodensword.jpg",
                            Name = "Bokuto",
                            Price = 24.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rubber Training Sais",
                            ImageName = "rubbersai.jpg",
                            Name = "Rubber Sais",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Rubber Training Knife for Training",
                            ImageName = "rubberknife.jpg",
                            Name = "Rubber Combat Knife",
                            Price = 14.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

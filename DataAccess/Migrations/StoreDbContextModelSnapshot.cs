﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Midnight",
                            Description = "A total powerhouse.",
                            ImagePath = "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-finish-select-202209-6-1inch-midnight_1.png",
                            Memory = 128,
                            Model = "iPhone 14",
                            Price = 799m
                        },
                        new
                        {
                            Id = 2,
                            Color = "Starlight",
                            Description = "Big and bigger.",
                            ImagePath = "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-plus_2__3.jpeg",
                            Memory = 128,
                            Model = "iPhone 14 Plus",
                            Price = 899m
                        },
                        new
                        {
                            Id = 3,
                            Color = "Space Black",
                            Description = "The ultimate iPhone.",
                            ImagePath = "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-black-1_4_2.jpeg",
                            Memory = 256,
                            Model = "iPhone 14 Pro",
                            Price = 1099m
                        },
                        new
                        {
                            Id = 4,
                            Color = "Deep Purple",
                            Description = "Pro. Beyond.",
                            ImagePath = "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-purple-1_9.jpeg",
                            Memory = 512,
                            Model = "iPhone 14 Pro Max",
                            Price = 1399m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

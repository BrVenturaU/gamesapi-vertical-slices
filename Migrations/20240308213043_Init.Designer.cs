﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerticalSliceArchitecture.Data;

#nullable disable

namespace VerticalSliceArchitecture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240308213043_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VerticalSliceArchitecture.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Name = "Horizon Forbidden West",
                            PlatformId = 2,
                            Publisher = "Sony Interactive Entertainment"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Animal Crossing: New Horizons",
                            PlatformId = 3,
                            Publisher = "Nintendo"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Halo Infinite",
                            PlatformId = 1,
                            Publisher = "Xbox Game Studios"
                        });
                });

            modelBuilder.Entity("VerticalSliceArchitecture.Domain.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "Microsoft",
                            Name = "Xbox Series X"
                        },
                        new
                        {
                            Id = 2,
                            Manufacturer = "Sony",
                            Name = "PlayStation 5"
                        },
                        new
                        {
                            Id = 3,
                            Manufacturer = "Nintendo",
                            Name = "Nintendo Switch"
                        });
                });

            modelBuilder.Entity("VerticalSliceArchitecture.Domain.Game", b =>
                {
                    b.HasOne("VerticalSliceArchitecture.Domain.Platform", "Platform")
                        .WithMany("Games")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("VerticalSliceArchitecture.Domain.Platform", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}

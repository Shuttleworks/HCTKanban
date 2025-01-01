﻿// <auto-generated />
using HCTKanban.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HCTKanban.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241219150037_createbirdboxteables")]
    partial class createbirdboxteables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HCTKanban.Models.BirdBox", b =>
                {
                    b.Property<int>("BirdBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BirdBoxId"));

                    b.Property<int>("BirdBoxStatusId")
                        .HasColumnType("int");

                    b.Property<int>("BirdBoxTypeId")
                        .HasColumnType("int");

                    b.HasKey("BirdBoxId");

                    b.ToTable("BirdBox");
                });

            modelBuilder.Entity("HCTKanban.Models.BirdBoxType", b =>
                {
                    b.Property<int>("BirdBoxTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BirdBoxTypeId"));

                    b.Property<string>("BirdBoxName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BirdBoxTypeId");

                    b.ToTable("BirdBoxType");
                });

            modelBuilder.Entity("HCTKanban.Models.Locations", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HCTKanban.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });
#pragma warning restore 612, 618
        }
    }
}

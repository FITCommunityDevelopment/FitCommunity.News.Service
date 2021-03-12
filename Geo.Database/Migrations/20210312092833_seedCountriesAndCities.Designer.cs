﻿// <auto-generated />
using System;
using Geo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Geo.Database.Migrations
{
    [DbContext(typeof(GeoDbContext))]
    [Migration("20210312092833_seedCountriesAndCities")]
    partial class seedCountriesAndCities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geo.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77e49d52-3f98-421e-95de-1827426defb8"),
                            CountryId = new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"),
                            Name = "Sarajevo"
                        },
                        new
                        {
                            Id = new Guid("13e7dbda-e5d6-4ba8-b96f-03c6d06bea89"),
                            CountryId = new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"),
                            Name = "Mostar"
                        },
                        new
                        {
                            Id = new Guid("8d41406b-f8dd-481e-b0f7-2003df64873a"),
                            CountryId = new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"),
                            Name = "Zagreb"
                        },
                        new
                        {
                            Id = new Guid("ca507cce-2047-4ddd-94ad-a40b64f6abab"),
                            CountryId = new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"),
                            Name = "Split"
                        });
                });

            modelBuilder.Entity("Geo.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33ec19f2-33ad-41e9-83e2-c8327790a665"),
                            Abbreviation = "BA",
                            Name = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            Id = new Guid("edd3905e-e0ba-4d2e-aa3c-c5d418081034"),
                            Abbreviation = "HR",
                            Name = "Country"
                        });
                });

            modelBuilder.Entity("Geo.Domain.City", b =>
                {
                    b.HasOne("Geo.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}

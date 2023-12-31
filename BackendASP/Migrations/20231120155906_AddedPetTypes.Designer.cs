﻿// <auto-generated />
using System;
using BackendASP.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendASP.Migrations
{
    [DbContext(typeof(PetCareContext))]
    [Migration("20231120155906_AddedPetTypes")]
    partial class AddedPetTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendASP.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Plural")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("PetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "dog.png",
                            Name = "hond",
                            Plural = "honden"
                        },
                        new
                        {
                            Id = 2,
                            Image = "black-cat.png",
                            Name = "kat",
                            Plural = "katten"
                        },
                        new
                        {
                            Id = 3,
                            Image = "rabbit.png",
                            Name = "konijn",
                            Plural = "konijnen"
                        },
                        new
                        {
                            Id = 4,
                            Image = "guinea-pig.png",
                            Name = "cavia",
                            Plural = "cavia's"
                        },
                        new
                        {
                            Id = 5,
                            Image = "hamster.png",
                            Name = "hamster",
                            Plural = "hamsters"
                        },
                        new
                        {
                            Id = 6,
                            Image = "rat.png",
                            Name = "rat",
                            Plural = "ratten"
                        },
                        new
                        {
                            Id = 7,
                            Image = "muis.png",
                            Name = "muis",
                            Plural = "muizen"
                        },
                        new
                        {
                            Id = 8,
                            Image = "dog.png",
                            Name = "kleine hond",
                            ParentId = 1,
                            Plural = "kleine honden"
                        },
                        new
                        {
                            Id = 9,
                            Image = "dog.png",
                            Name = "grote hond",
                            ParentId = 1,
                            Plural = "grote honden"
                        });
                });

            modelBuilder.Entity("BackendASP.Models.PetType", b =>
                {
                    b.HasOne("BackendASP.Models.PetType", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TpBooks.Data;

namespace TpBooks.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201016094930_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TpBooks.Bookdto", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("AverageRating")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("InfoLink")
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("PreviewLink")
                        .HasColumnType("text");

                    b.Property<string>("PrintType")
                        .HasColumnType("text");

                    b.Property<string>("PublishedDate")
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .HasColumnType("text");

                    b.Property<int>("RatingsCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("TpBooks.Shelvesdto", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shelves");
                });
#pragma warning restore 612, 618
        }
    }
}

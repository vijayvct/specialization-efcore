﻿// <auto-generated />
using Day3_Concurrency_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day3_Concurrency_Demo.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230321061529_InitialDbCreation")]
    partial class InitialDbCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Day3_Concurrency_Demo.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Contact = "999-000-8888",
                            FName = "Bill",
                            LName = "G"
                        },
                        new
                        {
                            PersonId = 2,
                            Contact = "222-999-0000",
                            FName = "Malcolm",
                            LName = "D"
                        },
                        new
                        {
                            PersonId = 3,
                            Contact = "333-555-1111",
                            FName = "James",
                            LName = "C"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

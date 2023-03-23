﻿// <auto-generated />
using System;
using Day4_EFCore_Inheritance_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day4_EFCore_Inheritance_Demo.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230323073347_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.BlogBase", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"), 1L, 1);

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.Blog", b =>
                {
                    b.HasBaseType("Day4_EFCore_Inheritance_Demo.Models.BlogBase");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL");

                    b.ToTable("SampleBlogs", (string)null);
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.RssBlog", b =>
                {
                    b.HasBaseType("Day4_EFCore_Inheritance_Demo.Models.BlogBase");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL");

                    b.ToTable("RssBlogs", (string)null);
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.Student", b =>
                {
                    b.HasBaseType("Day4_EFCore_Inheritance_Demo.Models.Person");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.Teacher", b =>
                {
                    b.HasBaseType("Day4_EFCore_Inheritance_Demo.Models.Person");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.Blog", b =>
                {
                    b.HasOne("Day4_EFCore_Inheritance_Demo.Models.BlogBase", null)
                        .WithOne()
                        .HasForeignKey("Day4_EFCore_Inheritance_Demo.Models.Blog", "BlogId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Day4_EFCore_Inheritance_Demo.Models.RssBlog", b =>
                {
                    b.HasOne("Day4_EFCore_Inheritance_Demo.Models.BlogBase", null)
                        .WithOne()
                        .HasForeignKey("Day4_EFCore_Inheritance_Demo.Models.RssBlog", "BlogId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

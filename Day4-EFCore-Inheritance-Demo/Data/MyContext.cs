using System;
using Day4_EFCore_Inheritance_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Day4_EFCore_Inheritance_Demo.Data;

public class MyContext:DbContext
{
    public DbSet<Person> People { get; set; }

    public DbSet<BlogBase> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseSqlServer("data source=CTAADPG02MWBG;initial catalog=EFCoreInheritanceDB1;integrated security=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>().HasBaseType<Person>();
        modelBuilder.Entity<Student>().HasBaseType<Person>();

        modelBuilder.Entity<Blog>().Property(b=>b.Url).HasColumnName("URL");
        modelBuilder.Entity<RssBlog>().Property(b=>b.Url).HasColumnName("URL");

        modelBuilder.Entity<Blog>().ToTable("SampleBlogs");
        modelBuilder.Entity<RssBlog>().ToTable("RssBlogs");
    }
}
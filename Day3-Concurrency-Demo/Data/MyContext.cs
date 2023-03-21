using System;
using Day3_Concurrency_Demo.Model;
using Microsoft.EntityFrameworkCore;

namespace Day3_Concurrency_Demo.Data;

class MyContext:DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=CTAADPG02MWBG;initial catalog=EFConcurrencyDB;integrated security=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().HasData
        (
            new Person{PersonId=1,FName="Bill",LName="G",Contact="999-000-8888"},
            new Person{PersonId=2,FName="Malcolm",LName="D",Contact="222-999-0000"},
            new Person{PersonId=3,FName="James",LName="C",Contact="333-555-1111"}
        );

        modelBuilder.Entity<Student>().HasData
        (
            new Student{Id=1,Name="Vijay",StudentType=StudentType.FullTime},
            new Student{Id=2,Name="Suresh",StudentType=StudentType.PartTime}
        );

        modelBuilder.Entity<Customer>().HasData
        (
            new Customer{Id=1,Name="Julia",CustomerType=CustomerType.Internal},
            new Customer{Id=2,Name="John",CustomerType=CustomerType.External}
        );

        modelBuilder.Entity<Customer>()
            .Property(c=>c.CustomerType).HasConversion<string>();
    }
}
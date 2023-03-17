using System;
using Microsoft.EntityFrameworkCore;
using Day1_EFCore_Demo.Models;
using Microsoft.Extensions.Logging;

namespace Day1_EFCore_Demo.Data;

public class AppDbContext:DbContext
{
    //connection string 
    string connstring="data source=CTAADPG02MWBG;initial catalog=EFDemoDB;user id=sa;password=Password_123";

    //DbSets
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories{get;set;}


    //Creating a Custom Console Logger
    public static readonly ILoggerFactory ConsoleLoggerFactory =
        LoggerFactory.Create(builder=>
        {
            builder.AddFilter((category,level)=>
            category==DbLoggerCategory.Database.Command.Name && level==LogLevel.Information)
            .AddConsole();
        });

    //Configure the database 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
        //.LogTo(Console.WriteLine)
        .UseSqlServer(connstring);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seed data in Category
        modelBuilder.Entity<Category>().HasData(
            new Category { Id=1,Name="Stationary"},
            new Category {Id=2,Name="Electronics"}
        );

        //Seed data in Products 
        modelBuilder.Entity<Product>().HasData(
            new Product{Id=1,Name="Pencil",Price=4.99,Description="Pencil",CategoryId=1},
            new Product{Id=2,Name="Fountain Pen",Price=299.99,Description="Fountain Pen",CategoryId=1},
            new Product{Id=3,Name="Steam Iron",Price=2999.99,Description="Steam Iron",CategoryId=2}
        );
    }
}
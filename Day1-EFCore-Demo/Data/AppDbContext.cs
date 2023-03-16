using System;
using Microsoft.EntityFrameworkCore;
using Day1_EFCore_Demo.Models;

namespace Day1_EFCore_Demo.Data;

public class AppDbContext:DbContext
{
    //connection string 
    string connstring="data source=CTAADPG02MWBG;initial catalog=EFDemoDB;user id=sa;password=Password_123";

    //DbSets
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories{get;set;}
    //Configure the database 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connstring);
    }
}
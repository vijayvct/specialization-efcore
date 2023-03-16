using Day1_EFCore_Demo.Data;
using Day1_EFCore_Demo.Models;

namespace Day1_EFCore_Demo;
class Program
{
    //Using Create and Drop API to perform CRUD operations on the database
    static void Main(string[] args)
    {
        //Creating DB Context object 
        AppDbContext context = new AppDbContext();

        //Create Database 
        Console.WriteLine("Press Enter to create database");
        Console.ReadLine();
        context.Database.EnsureCreated();
        Console.WriteLine("Database created successfully........");

        //Adding data into the table 
        Console.WriteLine("\nPress Enter to add data in the table");
        Console.ReadLine();
        List<Product> list =new List<Product>
        {
            new Product{Name="Pen",Price=9.99},
            new Product{Name="Wireless Mouse",Price=399.99}
        };

        context.Products.AddRange(list);
        context.SaveChanges();

        Console.WriteLine("Data Added Successfully..........");

        //Retrieving the data
        Console.WriteLine("\nPress Enetr to display data");
        Console.ReadLine();

        foreach(var p in context.Products)
        {
            Console.WriteLine($"Id = {p.Id},Name = {p.Name},Price = {p.Price}");
        }

        //Deleting Database 
        Console.WriteLine("\nPress Enter to delete database");
        Console.ReadLine();
        context.Database.EnsureDeleted();
        Console.WriteLine("Database deleted successfully......");
    }
}

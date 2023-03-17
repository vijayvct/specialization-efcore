using System;
using Day1_EFCore_Demo.Models;
using Day1_EFCore_Demo.Data;
using System.Collections.Generic;
using System.Linq;

namespace Day1_EFCore_Demo;

class Program01
{
    //Adding a Single Product
    static void AddSingleProduct()
    {
        AppDbContext context = new AppDbContext();

        Product product= new Product
        {
            Name="Pen",Price=9.99,Description="Ball Pen",CategoryId=1
        };

        Console.WriteLine("Current State = "+context.Entry(product).State);

        context.Products.Add(product);

        Console.WriteLine("State After Adding = "+context.Entry(product).State);
        context.SaveChanges();

        Console.WriteLine("Product Added...");
    }

    //Adding Multiple Products
    static void AddMultiplProducts()
    {
        List<Product> list = new List<Product>
        {
            new Product{Name="Memory Card",Price=399.99,Description="Storage Device",CategoryId=2},
            new Product{Name="Eraser",Price=6.99,Description="Eraser",CategoryId=1}
        };

        AppDbContext context = new AppDbContext();
        
        context.Products.AddRange(list);
        context.SaveChanges();

        Console.WriteLine("Products Added.......");
    }

    static void DisplayProducts()
    {
        AppDbContext context = new AppDbContext();
        //LINQ 
        // var products = from product in context.Products
        //                select product;
        var products= context.Products.ToList();

        foreach(var p in products)
        {
            Console.WriteLine($"Id ={p.Id},Name ={p.Name},Description= {p.Description},Price={p.Price}");
        }
    }

    static void UpdateProduct()
    {
        AppDbContext context = new AppDbContext();

        var product = context.Products.Find(5);

        Console.WriteLine("State before updated = "+context.Entry(product).State);
   
        if(product!=null)
        {
            product.Name="SanDisk 16GB Memory Card";
            product.Price=600;
            Console.WriteLine("State after update = "+context.Entry(product).State);
            context.SaveChanges();
            Console.WriteLine("Product Updated successfully....");
        }   
        else
        {
            Console.WriteLine("Unable to find the product for update");
        } 
    }

    static void DeleteProduct()
    {
        AppDbContext context=new AppDbContext();

        var product= (context.Products.Where(p=>p.Id==6)).FirstOrDefault();
        Console.WriteLine("State before delete = "+context.Entry(product).State);

        if(product!=null)
        {
            context.Products.Remove(product);
            Console.WriteLine("State after delete = "+context.Entry(product).State);
            context.SaveChanges();

            Console.WriteLine("Product deleted successfully");
        }
        else
        {
            Console.WriteLine("Unable to find the product for deletion");
        }
    }

    //Adding Related data
    static void AddCategoryProduct1()
    {
        var category = new Category
        {
            Name="Computers"
        };

        var p1=new Product{Name="Wireless Mouse",Price=678.99,Description="Wireless Mouse",CategoryId=3};
        var p2=new Product{Name="External HDD",Price=7878.99,Description="External HDD",CategoryId=3};

        AppDbContext context = new AppDbContext();
        context.AddRange(category,p1,p2);
        context.SaveChanges();

        Console.WriteLine("Data Added Successfully...."); 
    }

    static void AddCategoryProduct2()
    {
        var category= new Category
        {
            Name="Food Items",
            Products=new List<Product>
            {
                new Product{Name="Chips",Price=20},
                new Product{Name="Biscuits",Price=99.99}
            }
        };

        AppDbContext context = new AppDbContext();
        context.Add(category);
        context.SaveChanges();

        Console.WriteLine("Data Added Successfully....");
    }
    static void Main(string[] args)
    {
        //AddSingleProduct();
        //AddMultiplProducts();
        //DisplayProducts();
        //UpdateProduct();
        //DeleteProduct();
        //AddCategoryProduct1();
        AddCategoryProduct2();
    }
}
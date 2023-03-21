using System;
using Day1_EFCore_Demo.Models;
using Day1_EFCore_Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1_EFCore_Demo;

class Program03
{
    //The below method demonstrates the use of connected scenario/architecture in EF Core
    static void ConnectedScenario()
    {
        //Creating Context Object 
        AppDbContext context = new AppDbContext();

        //Adding a Category
        var category = new Category
        {
            Name ="Beverages"
        };

        Console.WriteLine("Category State before adding = "+context.Entry(category).State);//detached

        context.Categories.Add(category);
        Console.WriteLine("Category State after adding = "+context.Entry(category).State);//Added
        context.SaveChanges();

        //Retrieve the Category List 
        var categorylist = context.Categories.ToList();

        //Updating Categories
        foreach(var cat in categorylist)
        {
            cat.Name = "Edited "+cat.Name;
            Console.WriteLine("Updated Category State = "+context.Entry(cat).State);
        }

        context.SaveChanges();

        //Deleteing Category
        var deleteCategory = context.Categories.Find(5);
        Console.WriteLine("Category State before deleting = "+context.Entry(deleteCategory).State);
        context.Categories.Remove(deleteCategory);
        Console.WriteLine("Category State after deleting = "+context.Entry(deleteCategory).State);
        context.SaveChanges();
    }

    //The below method demonstrate the used of disconnected scenario in EF Core to 
    //perform Updation of an entity
    static void DisconnectedUpdate()
    {
        //Fethcing the record(product) for update
        AppDbContext context = new AppDbContext();
        var updateProduct = context.Products.Find(2);

        Console.WriteLine("Current State of Product = "+context.Entry(updateProduct).State);

        updateProduct.Name ="Parket Fountain Pen";

        //using a new context object to update data
        using(var updateContext =new AppDbContext())
        {
            Console.WriteLine("New State before updating = "+updateContext.Entry(updateProduct).State);

            updateContext.Attach(updateProduct);
            updateContext.Entry(updateProduct).State = EntityState.Modified;

            Console.WriteLine("New State after updating = "+context.Entry(updateProduct).State);

            updateContext.SaveChanges();

            Console.WriteLine("Record Updated Successfully....");
        }
    }

    static void DisconnectedDelete()
    {
        //Fethcing the record(product) for delete
        AppDbContext context = new AppDbContext();
        var deleteProduct = context.Products.Find(9);

        Console.WriteLine("Current State of Product = "+context.Entry(deleteProduct).State);

        using (var deleteContext=new AppDbContext())
        {
            Console.WriteLine("New state before deleting = "+deleteContext.Entry(deleteProduct).State);

            deleteContext.Attach(deleteProduct);
            deleteContext.Entry(deleteProduct).State= EntityState.Deleted;

            Console.WriteLine("New state after deleting = "+deleteContext.Entry(deleteProduct).State);

            deleteContext.SaveChanges();

            Console.WriteLine("Record Deleted Successfully.......");
        }

    }
    static void Main(string[] args)
    {
        //ConnectedScenario();
        //DisconnectedUpdate();
        DisconnectedDelete();
    }
}
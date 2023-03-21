using System;
using Day1_EFCore_Demo.Data;
using Day1_EFCore_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1_EFCore_Demo;

class Program02
{
    //Working with Stored Procedure
    static void StoredProcedure()
    {
        var context = new AppDbContext();

        Console.WriteLine("Enter the category id to be searched");
        int id = Convert.ToInt32(Console.ReadLine());

        //var category= (context.Categories.FromSqlRaw("exec GetCategory {0}",id)).ToList().FirstOrDefault();
        var category= (context.Categories.FromSqlInterpolated($"exec GetCategory {id}")).ToList().FirstOrDefault();
        if(category==null)
        {
            Console.WriteLine($"Category with id {id} not found");
        }
        else
        {
            Console.WriteLine($"Id = {category.Id},Name = {category.Name}");
        }
    }

    //Working with Functions 
    static void FunctionQuery()
    {
        var context = new AppDbContext();

        Console.WriteLine("Enter Category Id");
        int id = Convert.ToInt32(Console.ReadLine());

        var data = context.Products.FromSqlInterpolated($"select dbo.GetProductCount({id})").ToList();

        Console.WriteLine($"No of Products = {data.Count} in Category Id = {id}");
    }

    //Working with RAWSQL
    static void RawSql1()
    {
        var context = new AppDbContext();

        var products=context.Products
                        .FromSqlRaw("select * from Products").ToList();

        foreach(var product in products)
        {
            Console.WriteLine($"Id = {product.Id},Name = {product.Name}");
        }
    }

    static void RawSql2()
    {
        var context = new AppDbContext();

        var catid=3;

        var products = context.Products 
                        .FromSqlInterpolated($"select * from Products where categoryid={catid}");

        foreach(var product in products)
        {
            Console.WriteLine($"Id = {product.Id},Name = {product.Name}");
        }
    }
    static void Main(string[] args)
    {
        //StoredProcedure();
        //FunctionQuery();
        //RawSql1();
        RawSql2();
    }
}
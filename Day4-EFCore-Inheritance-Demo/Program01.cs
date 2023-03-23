using System;
using Day4_EFCore_Inheritance_Demo.Models;
using Day4_EFCore_Inheritance_Demo.Data;

namespace Day4_EFCore_Inheritance_Demo;

class Program01
{
    static void Main(string[] args)
    {
        var context = new MyContext();

        var transaction = context.Database.BeginTransaction();

        try
        {
            context.Blogs.Add(new Blog{Url="http://demo.com"});
            context.SaveChanges();

            context.Blogs.Add(new RssBlog{Url="http://abc.com"});
            context.SaveChanges();

            transaction.Commit();

            Console.WriteLine("Transaction Completed");
        }
        catch(Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Transaction rollbacked....");
        }
    }
}
using System;
using Day1_EFCore_Demo.Models;
using Day1_EFCore_Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1_EFCore_Demo;

class Program04
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();

        //Getting a person and changing its first name
        var person = context.People.Single(p=>p.PersonId==1);
        person.FName="James";

        //Changing the name of the person in the database to simulate concurrency
        //context.Database.ExecuteSqlRaw("Update person set ")


    }
}
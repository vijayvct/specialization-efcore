using System;

namespace Day1_EFCore_Demo.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    //Navigation Property 

    public List<Product> Products {get;set;}
}
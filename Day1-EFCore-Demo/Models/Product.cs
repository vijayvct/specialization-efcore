using System;

namespace Day1_EFCore_Demo.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }

    //Foreign Key 
    public int CategoryId { get; set; }

    //Navigation Property 
    public Category Category { get; set; }
}
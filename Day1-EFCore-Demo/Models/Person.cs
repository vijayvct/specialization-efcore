using System;
using System.ComponentModel.DataAnnotations;

namespace Day1_EFCore_Demo.Models;

public class Person
{
    public int PersonId { get; set; }
    public string FName { get; set; }
    
    [ConcurrencyCheck]
    public string LName { get; set; }

    public string ContactNumber{get;set;}
}
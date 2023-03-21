using System;
using System.ComponentModel.DataAnnotations;

namespace Day3_Concurrency_Demo.Model;

class Person
{
    public int PersonId { get; set; }
    public string FName { get; set; }

    [ConcurrencyCheck]
    public string LName { get; set; }
    public string Contact { get; set; }
}
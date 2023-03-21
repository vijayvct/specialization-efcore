using System;

namespace Day3_Concurrency_Demo.Model;

enum CustomerType
{
    Internal,
    External
}

class Customer 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CustomerType CustomerType { get; set; }
}
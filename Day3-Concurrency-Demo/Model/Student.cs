using System;

namespace Day3_Concurrency_Demo.Model;

enum StudentType
{
    FullTime,
    PartTime
}

class Student 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public StudentType StudentType { get; set; }
}
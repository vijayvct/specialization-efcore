using System;

namespace Day3_EF_Relation_Demo.Model;
//Using EF Core Conventions to create relationship

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    //Navigation
    public IEnumerable<Employee> Employees{get;set;}
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    //Foereign Key 
    public int DepartmentId { get; set; }

    //Navigation Property
    public EmployeeAddress EmployeeAddress { get; set; }

    public Department Department { get; set; }
}

public class EmployeeAddress
{
    public int Id { get; set; }
    public string AddreessLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string  Country { get; set; }
    public int ZipCode { get; set; }

    //Foreign Key 
    public int EmployeeId { get; set; }

    //Navigation Property 
    public Employee Employee { get; set; }
}
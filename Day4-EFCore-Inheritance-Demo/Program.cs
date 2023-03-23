using Day4_EFCore_Inheritance_Demo.Data;
using Day4_EFCore_Inheritance_Demo.Models;

namespace Day4_EFCore_Inheritance_Demo;
class Program
{
    static void Main(string[] args)
    {
        var context = new MyContext();

        var student = new Student{Name="Malcolm",EnrollmentDate=DateTime.Now};
        var teacher = new Teacher{Name="James",HireDate=DateTime.Now};

        context.AddRange(student,teacher);
        context.SaveChanges();

        Console.WriteLine("Record Added");
    }
}

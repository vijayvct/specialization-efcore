using Microsoft.EntityFrameworkCore;
using Day3_Concurrency_Demo.Model;
using Day3_Concurrency_Demo.Data;

namespace Day3_Concurrency_Demo;
class Program
{
    static void Main(string[] args)
    {
        MyContext context = new MyContext();

        var person = context.People.Single(p=>p.PersonId==2);
        //person.Contact="222-222-2222";
        person.LName="Dmello";

        context.Database
            .ExecuteSqlRaw("Update dbo.People set LName='Jobs' where PersonId=2");

        var savedData=false;

        while(!savedData)
        {
            try
            {
                context.SaveChanges();
                savedData= true;

                Console.WriteLine("Records updated........");
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Exception occured while updating records");

                foreach(var item in ex.Entries)
                {
                    if(item.Entity is Person)
                    {
                        var currentValues=item.CurrentValues;
                        var dbValues = item.GetDatabaseValues();

                        foreach (var prop in currentValues.Properties)
                        {
                            var currentValue= currentValues[prop];
                            var dbValue=dbValues[prop];
                        }

                        item.OriginalValues.SetValues(dbValues);
                    }
                    else
                    {
                        throw new NotSupportedException("Don't know handling concurrency conflict = "+item.Metadata.Name);
                    }
                }
            }
        }
    }
}

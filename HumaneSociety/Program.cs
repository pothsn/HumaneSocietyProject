using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> updates = new Dictionary<int, string>();
            
            /*updates.Add(2, "Glimore");
            Query.UpdateAnimal(1, updates);
            Console.ReadLine();*/
            



            //PointOfEntry.Run();

            Employee employee = new Employee() {EmployeeId= 1, FirstName="jim", LastName="xshf", UserName = "SBrunelli", Password="OnePunchMan1!", EmployeeNumber= 1, Email= "SBrunelli@gmail.com" };
            string input = "create";

            //Query.AddAnimal(new Animal());
            //Query.RunEmployeeQueries(employee, input);
            //Query.CreateNewEmployeeQueries(employee);
            //Query.ReadNewEmployeeQueries(employee);
            //Query.UpdateNewEmployeeQueries(employee);
            //Query.DeleteNewEmployeeQueries(employee);
            //var thing = Query.GetPendingAdoptions();
            //Console.WriteLine(thing.ToList().Count);

        }
    }
}

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

            
            updates.Add(5, "true");
            updates.Add(6, "true");
            updates.Add(3, "7");
            updates.Add(2, "Glimore");
            Query.SearchForAnimalsByMultipleTraits(updates);
            Console.ReadLine();




            //PointOfEntry.Run();

            //Employee employee = new Employee() {EmployeeId= 1, FirstName="Mike", LastName="Lee", UserName = "ME1990", Password="werewre", EmployeeNumber= 123, Email= "asfs@gmail.com" };
            //string input = "create";

            //Query.AddAnimal(new Animal());
            //Query.RunEmployeeQueries(employee, input);
            //Query.CreateNewEmployeeQueries(employee);
            //Query.ReadNewEmployeeQueries(employee);
            //Query.UpdateNewEmployeeQueries(employee);
            //Query.DeleteNewEmployeeQueries(employee);


        }
    }
}

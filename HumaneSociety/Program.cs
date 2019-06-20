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




            //Employee employee = new Employee() { FirstName = "Mike", LastName = "Lee", UserName = "ME1990", Password = "werewre", EmployeeNumber = 123, Email = "asfs@gmail.com" };
            //string input = "create";
            //Employee employee1 = new Employee() { FirstName = "steve", LastName = "Van", UserName = "stv", Password = "dsfs", EmployeeNumber = 34, Email = "stve@gmail.com" };
            //string input1 = "create";
            ////Query.AddAnimal(new Animal());
            //Query.RunEmployeeQueries(employee, input);
            //Query.RunEmployeeQueries(employee1, input1);


            ////Query.CreateNewEmployeeQueries(employee);
            ////Query.ReadNewEmployeeQueries(employee);
            ////Query.UpdateNewEmployeeQueries(employee);
            //Query.DeleteNewEmployeeQueries(employee);

            Adoption adoption = new Adoption();
            adoption.AnimalId = 1;
            adoption.ClientId = 1;
            
            //DateTime test = new DateTime(2019, 6, 20);

            Query.UpdateAdoption(true, adoption);



        }
    }
}

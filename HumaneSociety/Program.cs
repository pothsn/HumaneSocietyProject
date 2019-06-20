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


            
            //updates.Add(5, "true");
            //updates.Add(6, "true");
            //updates.Add(3, "7");
            //updates.Add(2, "Glimore");
            //Query.SearchForAnimalsByMultipleTraits(updates);
            //Console.ReadLine();



            //PointOfEntry.Run();


            //Employee employee = new Employee() {EmployeeId= 1, FirstName="Mike", LastName="Lee", UserName = "ME1990", Password="werewre", EmployeeNumber= 123, Email= "asfs@gmail.com" };
            //string input = "create";



            //Query.AddAnimal(new Animal());
            //Query.RunEmployeeQueries(employee, input);

            //Employee employee = new Employee() {FirstName="Mike", LastName="Lee", UserName = "ME1990", Password="werewre", EmployeeNumber= 123, Email= "asfs@gmail.com" };
            //string input = "create";
            //Employee employee1 = new Employee() { FirstName = "steve", LastName = "Van", UserName = "stv", Password = "dsfs", EmployeeNumber = 34, Email = "stve@gmail.com" };
            //string input1 = "create";
            ////Query.AddAnimal(new Animal());
            //Query.RunEmployeeQueries(employee, input);
            //Query.RunEmployeeQueries(employee1, input1);


            //Query.CreateNewEmployeeQueries(employee);
            //Query.ReadNewEmployeeQueries(employee);
            //Query.UpdateNewEmployeeQueries(employee);
            //Query.DeleteNewEmployeeQueries(employee);



            DateTime test = new DateTime(2019, 6, 20);
            // test.

            Animal animal = new Animal() { AnimalId = 1, Name = "Tom", Weight = 20, Age = 2 };
            // AnimalShot animalShot = new AnimalShot() { AnimalId = 2, ShotId = 323, DateReceived = test};
            IQueryable<AnimalShot> results = Query.GetShots(animal);




        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {        
        public static HumaneSocietyDataContext db;

        public static Employee employee;
        static Query()
        {
            db = new HumaneSocietyDataContext();

            employee = new Employee();
        }

        internal static List<USState> GetStates()
        {
            List<USState> allStates = db.USStates.ToList();       

            return allStates;
        }
            
        internal static Client GetClient(string userName, string password)
        {
            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

           
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.City = null;
                newAddress.USStateId = stateId;
                newAddress.Zipcode = zipCode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            // find corresponding Client from Db
            Client clientFromDb = null;

            try
            {
                clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("No clients have a ClientId that matches the Client passed in.");
                Console.WriteLine("No update have been made.");
                return;
            }
            
            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.City = null;
                newAddress.USStateId = clientAddress.USStateId;
                newAddress.Zipcode = clientAddress.Zipcode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }
        
        internal static void AddUsernameAndPassword(Employee employee)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeeFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return employeeFromDb;
            }
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName == null;
        }


        //// TODO Items: ////

        // TODO: Allow any of the CRUD operations to occur here --------------------------------------------------------------------------

        internal static void RunEmployeeQueries(Employee employee, string crudOperation)
        {
            switch (crudOperation)
            {
                case "create":
                    CreateNewEmployeeQueries(employee);
                    break;
                case "read":
                    ReadNewEmployeeQueries(employee);
                    break;
                case "update":
                    UpdateNewEmployeeQueries(employee);
                    break;
                case "delete":
                    DeleteNewEmployeeQueries(employee);
                    break;
                default:
                    UserInterface.DisplayUserOptions("Input not accepted please try again");
                    break;
            }
        }

        internal static void CreateNewEmployeeQueries(Employee employee)
        {
            bool employeeExists = db.Employees.Where(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.UserName == employee.UserName && e.Email == employee.Email).Any();

            if (!employeeExists)
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
        }

        internal static void ReadNewEmployeeQueries(Employee employee)
        {
            Employee readEmployee = db.Employees.Where(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.UserName == employee.UserName && e.Email == employee.Email).FirstOrDefault();
            if (readEmployee != null)
            {
                readEmployee.FirstName = employee.FirstName;
                readEmployee.LastName = employee.LastName;
                readEmployee.UserName = employee.UserName;
                readEmployee.Email = employee.Email;

                Console.WriteLine("First Name: " + readEmployee.FirstName);
                Console.WriteLine("Last Name: " + readEmployee.LastName);
                Console.WriteLine("Username: " + readEmployee.UserName);
                Console.WriteLine("Email: " + readEmployee.Email);
            }
        }
        internal static void UpdateNewEmployeeQueries(Employee employee)
        {
            Employee updateEmployee = db.Employees.Where(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.UserName == employee.UserName && e.Password == employee.Password && e.Email == employee.Email).FirstOrDefault();
            // update newEmployee information 
            // if the new employee isn't found in the Db, create and insert it
            if (updateEmployee != null)
            {
                updateEmployee.FirstName = "Shee";
                updateEmployee.LastName = "Chang";
                updateEmployee.UserName = "syc";
                updateEmployee.Password = "1234";
                updateEmployee.Email = "sheechang@gmail.com";

                db.SubmitChanges();
            }
        }
        internal static void DeleteNewEmployeeQueries(Employee employee)
        {
            bool deleteEmployee = db.Employees.Where(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.UserName == employee.UserName && e.Email == employee.Email).Any();
            if (deleteEmployee)
            {
                //deleteEmployee.EmployeeId = employee.EmployeeId;

                db.Employees.DeleteOnSubmit(employee);
                db.SubmitChanges(); 
            }

        }


internal static void AddAnimal(Animal animal)
        {
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
        }

        internal static Animal GetAnimalByID(int id)
        {
            Animal animal = db.Animals.Where(a => a.AnimalId == id).FirstOrDefault();
            return animal;
        }

        internal static void UpdateAnimal(int animalId, Dictionary<int, string> updates)
        {
            //query for the animal
            Animal animal = db.Animals.Where(a => a.AnimalId == animalId).FirstOrDefault();
            foreach (KeyValuePair<int, string> update in updates)
            {
                switch (update.Key)
                {
                    case 1:
                        animal.CategoryId = int.Parse(update.Value);
                        break;
                    case 2:
                        animal.Name = update.Value;
                        break;
                    case 3:
                        animal.Age = int.Parse(update.Value);
                        break;
                    case 4:
                        animal.Demeanor = update.Value;
                        break;
                    case 5:
                        animal.KidFriendly = bool.Parse(update.Value);
                        break;
                    case 6:
                        animal.Weight = int.Parse(update.Value);
                        break;
                    case 7:
                        animal.AnimalId = int.Parse(update.Value);
                        break;
                }
            }
            db.SubmitChanges();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            db.Animals.DeleteOnSubmit(animal);
            db.SubmitChanges();
        }
        
        // TODO: Animal Multi-Trait Search
        internal static IQueryable<Animal> SearchForAnimalsByMultipleTraits(Dictionary<int, string> searchParameters) // parameter(s)?
        {
            var animals = db.Animals;

            foreach (KeyValuePair<int, string> updates in searchParameters)
            {
                    //INCOMPLETE. MIKE H SAYS THIS IS THE HARDEST ONE. LEAVE FOR LAST.
            }

            return animals;
        }
         
        // TODO: Misc Animal Things
        internal static int GetCategoryId(string categoryName)
        {
            Category category = db.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
            return category.CategoryId;
        }
        
        internal static Room GetRoom(int animalId)
        {
            Room room = db.Rooms.Where(a => a.AnimalId == animalId).FirstOrDefault();
            return room;
        }
            
        internal static int GetDietPlanId(string dietPlanName)
        {
            DietPlan dietPlans = db.DietPlans.Where(d => d.Name == dietPlanName).FirstOrDefault();
            return dietPlans.DietPlanId;
        }

        // TODO: Adoption CRUD Operations
        internal static void Adopt(Animal animal, Client client)
        {
            db.Adoptions.InsertOnSubmit(new Adoption() { AnimalId = animal.AnimalId, ClientId = client.ClientId, AdoptionFee = 75 });
            db.SubmitChanges();
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            Adoption adoption = new Adoption();
            var results = db.Adoptions.Where(a => a.ApprovalStatus == "pending");
            return results;
        }

        internal static void UpdateAdoption(bool approvalStatus, Adoption adoption)
        {
            var thisAdoption = db.Adoptions.Where(a => a.AnimalId == adoption.AnimalId && a.ClientId == adoption.ClientId).Single();
           
                if(approvalStatus == true)
                {
                    adoption.ApprovalStatus = "approved";

                }
                else 
                {
                    adoption.ApprovalStatus = "pending";
                    //db.SubmitChanges();
                }
            db.Adoptions.InsertOnSubmit(adoption);
            //db.SubmitChanges();
        }

        internal static void RemoveAdoption(int animalId, int clientId)
        {
            Adoption adoption = db.Adoptions.Where(a => a.AnimalId == animalId && a.ClientId == clientId).FirstOrDefault();
            db.Adoptions.DeleteOnSubmit(adoption);
            db.SubmitChanges();
        }

        // TODO: Shots Stuff-------------------------------------------------------------------------------
        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            IQueryable<AnimalShot> animalShots = db.AnimalShots.Where(a => a.AnimalId == animal.AnimalId);  //Why can't do ToList() b/c not using List<>; it's IQueryable;
            return animalShots;
        }

        internal static void UpdateShot(string shotName, Animal animal)
        {
            var animalShotUpdate = db.AnimalShots.Where(a => a.AnimalId == animal.AnimalId);
            var animalShotUpdate1 = db.AnimalShots.Select(a => a.ShotId).FirstOrDefault();
            var updateShot = db.Shots.Select(s => s.ShotId);
            var updateShot1 = db.Shots.Select(s => s.Name == shotName);

            //if (updateShot1 != null)
            //{
            //    db.Shots.InsertOnSubmit(updateShot1);
            //    db.SubmitChanges();
            //}
        }
    }
}
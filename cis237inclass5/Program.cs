using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            // make new instance of the car class
            // Probably going to be CarsFInitialLName for you.
            CarsJMeachumEntities carsTestEntities = new CarsJMeachumEntities();

            // List out all of the cars in the table
            Console.WriteLine("Print the list");

            foreach(Car car in carsTestEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            // *******************
            // Find a specific one by any property
            // ****************

            // Call the Where method on the table Cars and pass a lambda expression
            // for the criteria we are looking for. There is nothing special about 
            // the word car in the part that reads: car => card.id == "V0.." It could be 
            // any character we want it to be.
            // It's just a variable name for he current car wea re considering
            // in the expression. This will automatcially loop through all the Cars,
            // and run the expression against each of them. When the result is finally
            // true, it will return that car.
            Car carToFind = // want to get car out of cars where car.id = "V0..."
                carsTestEntities.Cars.Where(car => car.id == "V0LCD1814").First();

            // We can look for a specific model from the database with a where based 
            // on any criteria we want. Here is one this is looking to match the Car's
            // model instead 
            Car otherCarToFind = carsTestEntities.Cars.Where(car => car.model == "Challenger").First();

            Console.WriteLine();
            Console.WriteLine("Find 2 specific cars: ");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);
            Console.WriteLine();

            // Pull out a car from the table based on the id which is the primary key
            // If the record doesn't exist in the database, it will return null, so check
            // what you get back and see if it is null. If so, it doesn't exist
            Car foundCar = carsTestEntities.Cars.Find("V0LCD1814");
            Console.WriteLine(foundCar.id + " " + foundCar.make);

            Car newCarToAdd = new Car();

            // Assign properties to the parts of the model
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 600;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2017";
            newCarToAdd.type = "Car";

            try
            {
                // Add the new car to the Cars collection
                carsTestEntities.Cars.Add(newCarToAdd);

                // This method does the work of saving the changes to the actual database
                carsTestEntities.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                carsTestEntities.Cars.Remove(newCarToAdd);
            }

            Console.WriteLine();
            carToFind = carsTestEntities.Cars.Find("88888");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);

            Car carToFindForDelete = carsTestEntities.Cars.Find("88888");

            // Remove the car from the cars collection
            carsTestEntities.Cars.Remove(carToFindForDelete);

            carsTestEntities.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Deleted the added car. Looking to see if it still in the db");

            // Try to get the car out of the database, and print it out
            carToFindForDelete = carsTestEntities.Cars.Find("88888");
            if (carToFindForDelete == null)
            {
                Console.WriteLine("The model you are looking for does not exist");
            }

        }
    }
}

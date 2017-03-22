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

        }
    }
}

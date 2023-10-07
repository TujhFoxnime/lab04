using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
                new Car { Name = "Daewoo Matiz", ProductionYear = 2002, MaxSpeed = 200},
                new Car { Name = "Lada Kalina", ProductionYear = 2008, MaxSpeed = 230},
                new Car { Name = "KAMAZ", ProductionYear = 2007, MaxSpeed = 160},
                new Car { Name = "Daewoo Nexia", ProductionYear = 2011, MaxSpeed = 220},
                new Car { Name = "Lada Granta", ProductionYear = 2011, MaxSpeed = 230},
                new Car { Name = "ZIL", ProductionYear = 1997, MaxSpeed = 140}
            };

            /////////////////////////////////
            CarCatalog catalog = new CarCatalog(cars);


            Console.WriteLine("Direct iteration:");
            foreach (var car in catalog)
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");

            Console.WriteLine("Reverse iteration:");
            foreach (var car in catalog.GetReverseEnumerator())
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");

            Console.WriteLine("ProductionYear iteration (2011):");
            foreach (var car in catalog.GetProductionYearEnumerator(2011))
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");

            Console.WriteLine("MaxSpeed iteration 230 km/h:");
            foreach (var car in catalog.GetMaxSpeedEnumerator(230))
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");
            ///////////////////////////////

            Console.WriteLine("Sort by name:");
            Array.Sort(cars, new CarComparer("Name"));
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");

            Console.WriteLine("Sort by production year:");
            Array.Sort(cars, new CarComparer("Production Year"));
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
            Console.WriteLine("");

            Console.WriteLine("Sort by max speed:");
            Array.Sort(cars, new CarComparer("Max Speed"));
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} ({car.ProductionYear}) {car.MaxSpeed} km/h");
            }
        }
    }
}

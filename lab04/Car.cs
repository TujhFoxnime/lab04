using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class Car : IComparable<Car>
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        public int CompareTo(Car other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    class CarComparer : IComparer<Car>
    {
        private string command;
        public CarComparer(string _command)
        {
            command = _command;
        }
        public int Compare(Car car1, Car car2)
        {
            switch (command)
            {
                case "Name": return car1.Name.CompareTo(car2.Name);
                case "Production Year": return car1.ProductionYear.CompareTo(car2.ProductionYear);
                case "Max Speed": return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
                default: throw new ArgumentException($"Invalid command for sorting: {command}");
            }
        }
    }



    class CarCatalog : IEnumerable<Car>
    {
        private Car[] cars;
        public CarCatalog(Car[] _cars) 
        {
            this.cars = _cars;
        }

        public IEnumerator<Car> GetEnumerator()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                yield return cars[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Car> GetReverseEnumerator()
        {
            for (int i = cars.Length - 1; i >= 0; i--) { yield return cars[i]; }
        }

        public IEnumerable<Car> GetProductionYearEnumerator(int year)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].ProductionYear == year) { yield return cars[i]; }
            }
        }

        public IEnumerable<Car> GetMaxSpeedEnumerator(int speed)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].MaxSpeed == speed) { yield return cars[i]; }
            }
        }
    }
}

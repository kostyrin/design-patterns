using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven");
        }
    }

    public class Driver
    {
        public int Age { get; set; }
    }

    public class CarProxy : ICar
    {
        private Driver _driver;
        private Car _car = new Car();

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age > 18)
            {
                _car.Drive();
            }
            else
            {
                Console.WriteLine("too young");
            }
        }
    }
}

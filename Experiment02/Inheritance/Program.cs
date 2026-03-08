using System;

namespace Inheritance
{

    class Vehicle
    {
        public string brand = "Ford";//Vehicle field
        public void honk()
        {
            Console.WriteLine("TTTTT");
        }
    }

    class Car : Vehicle //derived class(child)
    {
        public string modelName = "Mustang"; //car field
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.honk();

            Console.WriteLine(myCar.brand + " " + myCar.modelName);
        }
    }
}

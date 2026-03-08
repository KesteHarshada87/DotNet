using System;

namespace Constructor
{
    class Program
    {

        public String model;

        public Program(String modelName)
        {
            model = modelName;
        }
        static void Main(string[] args)
        {
            Program ford = new Program("Mustang");
            Console.WriteLine(ford.model);
        }
    }
}

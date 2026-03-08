using System;

namespace Method_Parameters
{
    class Program
    {

        static void MyMethod(string fname = "None")
        {
            Console.WriteLine(fname + " Keste");
        }
        static void Main(string[] args)
        {
            MyMethod("Harshada");
            MyMethod("Tanu");
            MyMethod("Sanu");
            //Default Parameter
            MyMethod(); 
        }
    }
}

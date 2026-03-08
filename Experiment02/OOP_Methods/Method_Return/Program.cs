using System;

namespace Method_Return
{
    class Program
    {

        static int MyMethod(int x)
        {
            return 5 + x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MyMethod(8));

            int z = MyMethod(9);
            Console.WriteLine(z);
        }
    }
}

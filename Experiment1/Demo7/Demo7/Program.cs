//Boolean

using System;

namespace Demo7
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 9;
            Console.WriteLine(x > y);

            int x1 = 10;
            Console.WriteLine(x == 10);

            int myAge = 25;
            int votingAge = 18;

            if (myAge >= votingAge)
            {
                Console.WriteLine("Old enough to vote!");
            }
            else
            {
                Console.WriteLine("Not old enough to vote.");
            }
        }
    }
}

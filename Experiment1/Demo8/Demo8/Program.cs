//if-else

using System;

namespace Demo8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 20;
            int y = 18;
            if (x > y)
            {
                Console.WriteLine("x is greater than y");
            }

            int time = 20;
            if (time < 18)
            {
                Console.WriteLine("Good day.");
            }
            else
            {
                Console.WriteLine("Good evening.");
            }


            int time1 = 22;
            if (time1 < 10)
            {
                Console.WriteLine("Good morning.");
            }
            else if (time1 < 20)
            {
                Console.WriteLine("Good day.");
            }
            else
            {
                Console.WriteLine("Good evening.");
            }

            int time3 = 20;
            string result = (time3 < 18) ? "Good day." : "Good evening.";
            Console.WriteLine(result);
        }
    }
}

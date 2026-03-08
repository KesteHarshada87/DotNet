//Strings

using System;

namespace Demo6
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting2 = "Nice to meet you!";

            string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("The length of the txt string is: " + txt.Length);

            string txt1 = "Hello World";
            Console.WriteLine(txt1.ToUpper());  
            Console.WriteLine(txt1.ToLower());

            string name1 = "Harshada";
            string name2 = "Keste";
            string name = string.Concat(name1, name2);//cancatenation
            Console.WriteLine(name);

            string fullname = $"My full name is {name1} {name2}";//Interpolation
            Console.WriteLine(fullname);

            string myString = "Hello";
            Console.WriteLine(myString[0]);




        }
    }
}

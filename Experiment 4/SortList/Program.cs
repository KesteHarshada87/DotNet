// Sort List using Lambda Expressions

using System;
using System.Collections.Generic;
using System.Linq;
namespace SortList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorting a List using Lambda Expressions!");

            
            List<int> numbers = new List<int> { 5, 2, 9, 1, 5, 6 };

            Console.WriteLine("Original List:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

        
            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

            Console.WriteLine("Sorted List:");
            sortedNumbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
        }
    }
}
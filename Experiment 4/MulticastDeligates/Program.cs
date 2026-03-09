// Multicast Delegates Example

using System;
namespace MulticastDelegates
{
    class Program
    {
    
        delegate void Operation(string message);

        static void Main(string[] args)
        {
            Console.WriteLine("Multicast Delegates Example!");

        
            Operation operation1 = OperationOne;
            Operation operation2 = OperationTwo;

            
            Operation multicastOperation = operation1 + operation2;

            
            multicastOperation("Hello, Multicast Delegates!");
        }

        
        static void OperationOne(string message)
        {
            Console.WriteLine($"Operation One: {message}");
        }

        static void OperationTwo(string message)
        {
            Console.WriteLine($"Operation Two: {message}");
        }
    }
}
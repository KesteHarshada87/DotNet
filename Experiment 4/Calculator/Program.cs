// Calculator using Delegates

using System;
namespace Calculator
{
    class Program
    {
        
        delegate double Operation(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");

        
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

        
            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            
            Console.Write("Enter the operation (+, -, *, /): ");
            string op = Console.ReadLine();

            
            Operation operation = null;

            switch (op)
            {
                case "+":
                    operation = Add;
                    break;
                case "-":
                    operation = Subtract;
                    break;
                case "*":
                    operation = Multiply;
                    break;
                case "/":
                    operation = Divide;
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    return;
            }

            
            double result = operation(num1, num2);
            Console.WriteLine($"The result of {num1} {op} {num2} is: {result}");
        }

        
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero!");
                return 0; 
            }
            return a / b;
        }
    }
}


// 5. Where we use Delagates and lambda expressions in company or industry?
// Delegates and lambda expressions are widely used in various industries for tasks such as event handling, asynchronous programming, and functional programming. 
// They allow developers to write more flexible and reusable code, making it easier to manage complex applications and improve performance.

// 6. What is LINQ Queries
// LINQ (Language Integrated Query) is a powerful feature in C# that allows developers to query and manipulate data in a more intuitive and readable way.
// It provides a consistent syntax for querying different data sources, such as collections, databases, XML, and more. LINQ queries can be written using method syntax or query syntax, making it easier to filter, sort, and transform data efficiently.

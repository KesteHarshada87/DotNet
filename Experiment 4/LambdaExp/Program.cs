// Replace methods with lambda expressions

using System;
namespace LambdaExp
{
    class Program
    {
        
        delegate double Operation(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator with Lambda Expressions!");

        
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
                    operation = (a, b) => a + b;
                    break;
                case "-":
                    operation = (a, b) => a - b;
                    break;
                case "*":
                    operation = (a, b) => a * b;
                    break;
                case "/":
                    operation = (a, b) =>
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Cannot divide by zero!");
                            return 0; 
                        }
                        return a / b;
                    };
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    return;
            }

        
            double result = operation(num1, num2);
            Console.WriteLine($"The result of {num1} {op} {num2} is: {result}");
        }
    }
}


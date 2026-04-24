using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Program Started...");

        // Call async method
        Task task = DoWorkAsync();

        Console.WriteLine("Main thread continues working...");

        await task;

        Console.WriteLine("Program Finished.");
        Console.ReadLine();
    }

    // Async method
    static async Task DoWorkAsync()
    {
        Console.WriteLine("Task started...");

        // Simulating long-running work (3 seconds)
        await Task.Delay(3000);

        Console.WriteLine("Task completed after delay.");
    }
}
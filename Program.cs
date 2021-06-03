using System;

namespace Payslip2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var userInput = new UserInput();
            
            Console.WriteLine("Welcome to the payslip generator!");
            
            userInput.GeneratePayslip();
            
        }
    }
}

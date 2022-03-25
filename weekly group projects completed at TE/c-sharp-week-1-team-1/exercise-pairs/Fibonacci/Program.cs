using System;
namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt user for number
            Console.Write("Please enter a number: ");

            //this takes in the users input and ALWAYS returns a string
            string initialInput = Console.ReadLine();

            int num = -1;
            while (!int.TryParse(initialInput, out num))
            {
                Console.Write("Not an integer. Please type in an integer: ");

                initialInput = Console.ReadLine();
            }
            //(extra carriage return)
            Console.WriteLine();

            //convert string to int
            int maxNumber = int.Parse(initialInput);

            //output fibinacci numbers leading to input number
            int a = 0;
            int b = 1;
            int c = a + b;
            Console.Write(a + ", " + b);
            while (c <= maxNumber)
            {
                Console.Write(", " + c);
                a = b;
                b = c;
                c = a + b;
            }

        }
    }
}



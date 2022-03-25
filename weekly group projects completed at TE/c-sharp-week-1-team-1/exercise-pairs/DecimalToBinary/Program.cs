using System;
namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            //get input from user
            Console.Write("Please enter in a series of decimal values (separated by spaces): ");
            string initialInput = Console.ReadLine();
            Console.WriteLine();

            //converts string to array
            string[] inputs = initialInput.Split(" ");


            //determines correct usage and reprompts user otherwise
            int num = -1;
            for (int i = 0; i < inputs.Length; i++)
            {
                //ensures int
                if (!int.TryParse(inputs[i], out num))
                {
                    Console.Write("Not a positive integer. Please type in a series of integers separated by a space: ");

                    initialInput = Console.ReadLine();
                    inputs = initialInput.Split(" ");
                    i = -1;
                }
                //ensures positive
                else if (int.Parse(inputs[i]) < 0)
                {
                    Console.Write("Not a positive integer. Please type in a series of integers separated by a space: ");

                    initialInput = Console.ReadLine();
                    inputs = initialInput.Split(" ");
                    i = -1;
                }
            }

            //convert array of strings to ints
            int[] numbers = new int[inputs.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(inputs[i]);
            }
            //(extra carriage return)
            Console.WriteLine();

            //cycle through array
            string[] finalBinaryNumbers = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                string binaryHolder = "";
                //returns 0 when input number is 0
                if (numbers[i] == 0)
                {
                    binaryHolder = "0";
                }
                //convert to binary then stores binary string into finalBinaryNumbers
                while (numbers[i] >= 1)
                {
                    //outputs "0" and "1" by determination of the divisor and stores the decimal into the string binaryHolder
                    if (numbers[i] % 2 == 1)
                    {
                        binaryHolder = "1" + binaryHolder;
                        numbers[i] = (numbers[i] - 1) / 2;
                    }
                    else
                    {
                        binaryHolder = "0" + binaryHolder;
                        numbers[i] = numbers[i] / 2;
                    }
                }
                finalBinaryNumbers[i] = binaryHolder;
            }
            //output array of finalBinaryNumbers onto console
            for (int i = 0; i < finalBinaryNumbers.Length; i++)
            {
                Console.WriteLine(inputs[i] + " in binary is " + finalBinaryNumbers[i]);
            }

        }
    }
}

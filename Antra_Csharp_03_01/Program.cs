using System;

namespace ReverseAndFibonacci
{
    class Program
    {
        // Method to generate numbers (creates an array of 10 numbers)
        static int[] GenerateNumbers()
        {
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = i + 1;
            }
            return numbers;
        }

        // Method to reverse the array
        static void Reverse(int[] numbers)
        {
            int temp;
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                // Swapping elements
                temp = numbers[i];
                numbers[i] = numbers[numbers.Length - i - 1];
                numbers[numbers.Length - i - 1] = temp;
            }
        }

        // Method to print the array
        static void PrintNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        // Recursive method to calculate Fibonacci
        static int Fibonacci(int n)
        {
            // Base case
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static void Main(string[] args)
        {
            // Part 1: Reverse Array
            Console.WriteLine("Original Array:");
            int[] numbers = GenerateNumbers();
            PrintNumbers(numbers);

            Reverse(numbers);
            Console.WriteLine("Reversed Array:");
            PrintNumbers(numbers);

            // Part 2: Fibonacci Sequence
            Console.WriteLine("First 10 Fibonacci numbers:");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine();
        }
    }
}
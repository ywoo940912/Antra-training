using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // 1.
        Console.WriteLine("Enter your favorite color:");
        string color = Console.ReadLine();
        Console.WriteLine("Enter your astrology sign:");
        string sign = Console.ReadLine();
        Console.WriteLine("Enter your street address number:");
        string address = Console.ReadLine();
        Console.WriteLine($"Your hacker name is {color}{sign}{address}.");
        
        // 2.
        Console.WriteLine("Data Type Sizes and Ranges:");
        Console.WriteLine($"sbyte: {sizeof(sbyte)} bytes, Min: {sbyte.MinValue}, Max: {sbyte.MaxValue}");
        Console.WriteLine($"byte: {sizeof(byte)} bytes, Min: {byte.MinValue}, Max: {byte.MaxValue}");
        Console.WriteLine($"short: {sizeof(short)} bytes, Min: {short.MinValue}, Max: {short.MaxValue}");
        Console.WriteLine($"ushort: {sizeof(ushort)} bytes, Min: {ushort.MinValue}, Max: {ushort.MaxValue}");
        Console.WriteLine($"int: {sizeof(int)} bytes, Min: {int.MinValue}, Max: {int.MaxValue}");
        Console.WriteLine($"uint: {sizeof(uint)} bytes, Min: {uint.MinValue}, Max: {uint.MaxValue}");
        Console.WriteLine($"long: {sizeof(long)} bytes, Min: {long.MinValue}, Max: {long.MaxValue}");
        Console.WriteLine($"ulong: {sizeof(ulong)} bytes, Min: {ulong.MinValue}, Max: {ulong.MaxValue}");
        Console.WriteLine($"float: {sizeof(float)} bytes, Min: {float.MinValue}, Max: {float.MaxValue}");
        Console.WriteLine($"double: {sizeof(double)} bytes, Min: {double.MinValue}, Max: {double.MaxValue}");
        Console.WriteLine($"decimal: {sizeof(decimal)} bytes, Min: {decimal.MinValue}, Max: {decimal.MaxValue}");

        // 3.
        Console.WriteLine("Enter number of centuries:");
        int centuries = int.Parse(Console.ReadLine());
        long years = centuries * 100;
        long days = years * 36524 / 100;
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

        // 4.
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
            else if (i % 3 == 0) Console.WriteLine("Fizz");
            else if (i % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(i);
        }

        // 5.
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
            if (i == 255) break; // Prevent overflow
        }

        // 6.
        int correctNumber = new Random().Next(1, 4);
        Console.WriteLine("Guess a number between 1 and 3:");
        int guessedNumber = int.Parse(Console.ReadLine());
        if (guessedNumber < 1 || guessedNumber > 3) Console.WriteLine("Invalid guess!");
        else if (guessedNumber < correctNumber) Console.WriteLine("Too low!");
        else if (guessedNumber > correctNumber) Console.WriteLine("Too high!");
        else Console.WriteLine("Correct!");

        // 7.
        int height = 5;
        for (int i = 1; i <= height; i++)
        {
            Console.Write(new string(' ', height - i));
            Console.WriteLine(new string('*', i * 2 - 1));
        }

        // 8.
        Console.WriteLine("Enter your birthdate (yyyy-mm-dd):");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        int daysOld = (DateTime.Now - birthDate).Days;
        Console.WriteLine($"You are {daysOld} days old.");
        Console.WriteLine($"Your next 10,000-day anniversary is on: {birthDate.AddDays((daysOld / 10000 + 1) * 10000)}");

        // 9.
        int hour = DateTime.Now.Hour;
        if (hour >= 5 && hour < 12) Console.WriteLine("Good Morning");
        if (hour >= 12 && hour < 17) Console.WriteLine("Good Afternoon");
        if (hour >= 17 && hour < 21) Console.WriteLine("Good Evening");
        if (hour >= 21 || hour < 5) Console.WriteLine("Good Night");

        // 10.
        for (int outer = 1; outer <= 4; outer++)
        {
            for (int inner = 0; inner <= 24; inner += outer)
            {
                Console.Write(inner + (inner < 24 ? "," : ""));
            }
            Console.WriteLine();
        }
    }
}

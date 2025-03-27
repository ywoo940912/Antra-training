using System;
using System.Collections.Generic;
using System.Linq;

class Antra_Csharp_02_Array
{
    static void Main()
    {
        CopyArray(); // 1.
        WaitForNext();

        ManageList(); // 2.
        WaitForNext();

        FindPrimes(); // 3.
        WaitForNext();

        RotateArrayAndSum(); // 4/.
        WaitForNext();

        FindLongestEqualSequence(); // 5.
        WaitForNext();

        FindMostFrequentNumber(); // 6.
    }

    static void CopyArray()
    {
        int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copiedArray = new int[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }
        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));
        Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));
    }

    static void ManageList()
    {
        List<string> items = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, -- to clear, next to move on):");
            string input = Console.ReadLine();
            if (input == "next") break;
            if (input == "--") items.Clear();
            else if (input.StartsWith("+ ")) items.Add(input.Substring(2));
            else if (input.StartsWith("- ")) items.Remove(input.Substring(2));
            Console.WriteLine("Current List: " + string.Join(", ", items));
        }
    }

    static void FindPrimes()
    {
        Console.Write("Enter start number: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Enter end number: ");
        int end = int.Parse(Console.ReadLine());

        int[] primes = FindPrimesInRange(start, end);
        Console.WriteLine("Primes in range: " + string.Join(", ", primes));
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            if (IsPrime(i)) primes.Add(i);
        }
        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void RotateArrayAndSum()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Console.Write("Enter number of rotations: ");
        int k = int.Parse(Console.ReadLine());

        int[] sumArray = new int[arr.Length];
        for (int r = 0; r < k; r++)
        {
            int last = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = last;
            for (int i = 0; i < arr.Length; i++)
            {
                sumArray[i] += arr[i];
            }
        }
        Console.WriteLine("Sum Array: " + string.Join(", ", sumArray));
    }

    static void FindLongestEqualSequence()
    {
        int[] arr = { 2, 1, 1, 2, 2, 2, 1, 3, 3, 3, 3, 1 };
        int maxCount = 1, count = 1, number = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1]) count++;
            else count = 1;
            if (count > maxCount)
            {
                maxCount = count;
                number = arr[i];
            }
        }
        Console.WriteLine("Longest sequence: " + string.Join(" ", Enumerable.Repeat(number, maxCount)));
    }

    static void FindMostFrequentNumber()
    {
        int[] arr = { 4, 4, 2, 3, 3, 3, 4, 4, 4, 5 };
        var groups = arr.GroupBy(n => n).OrderByDescending(g => g.Count()).ThenBy(g => Array.IndexOf(arr, g.Key));
        Console.WriteLine("Most frequent number: " + groups.First().Key);
    }

    static void WaitForNext()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

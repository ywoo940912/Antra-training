using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Antra_Csharp_02_String
{
    static void Main()
    {
        ReverseString(); // 1.
        WaitForNext();

        ReverseSentenceWords(); // 2.
        WaitForNext();

        ExtractPalindromes(); // 3.
        WaitForNext();

        ParseURL(); // 4.
    }

    static void ReverseString()
    {
        Console.Write("Enter a string to reverse: ");
        string input = Console.ReadLine();
        
        // Method 1: Using char array
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine("Reversed (char array method): " + new string(charArray));
        
        // Method 2: Using loop
        string reversed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }
        Console.WriteLine("Reversed (loop method): " + reversed);
    }

    static void ReverseSentenceWords()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();
        string[] words = Regex.Split(sentence, "([.,:;=()&\\[\\]\"'\\/!? ])");
        Array.Reverse(words);
        Console.WriteLine("Reversed words: " + string.Join("", words));
    }

    static void ExtractPalindromes()
    {
        Console.Write("Enter a text: ");
        string text = Console.ReadLine();
        HashSet<string> palindromes = new HashSet<string>();
        
        foreach (Match match in Regex.Matches(text, "\\b\\w+\\b"))
        {
            string word = match.Value;
            if (word.Length > 1 && word.Equals(new string(word.Reverse().ToArray()), StringComparison.OrdinalIgnoreCase))
            {
                palindromes.Add(word);
            }
        }
        
        Console.WriteLine("Unique palindromes: " + string.Join(", ", palindromes.OrderBy(p => p)));
    }

    static void ParseURL()
    {
        Console.Write("Enter a URL: ");
        string url = Console.ReadLine();
        
        var match = Regex.Match(url, @"^(?:(?<protocol>\w+)://)?(?<server>[^/]+)(?:/(?<resource>.*))?$");
        string protocol = match.Groups["protocol"].Success ? match.Groups["protocol"].Value : "";
        string server = match.Groups["server"].Value;
        string resource = match.Groups["resource"].Success ? match.Groups["resource"].Value : "";
        
        Console.WriteLine("[protocol] = \"" + protocol + "\"");
        Console.WriteLine("[server] = \"" + server + "\"");
        Console.WriteLine("[resource] = \"" + resource + "\"");
    }

    static void WaitForNext()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

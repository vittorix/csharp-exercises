using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;
public class Strings 
{    
    public static void exec()
    {
        // see https://learn.microsoft.com/en-us/dotnet/csharp/how-to/
        //  https://learn.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings

        U.p(@"------------Verbatim string literal 
            c:\program/\n%$#@^&*()");
        U.p("\n-------------raw string\n" + """starts with "3" marks" literal c:\program/\n%$#@^&*()""");

        U.p("\n ---------------Interpolated String");
        var age = 50;
        var jh = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
        Console.WriteLine($"{jh.firstName} {jh.lastName} was an African American poet born in {jh.born}.");
        Console.WriteLine($"at the age of {age}.");
        Console.WriteLine($"He'd be over {Math.Round((2018d - jh.born) / 100d) * 100d} years old today.");

        var var1 = 123; 
        var var2 = 234;
        Console.WriteLine("\n-----------Composite formatting: {0} {1}.", var1, var2);

        string s1 = "abcdefghi";
        U.p(s1.Substring(7, 2));
        U.p(s1.Replace("def", "DEF"));
        U.p(s1.IndexOf("c"));

        U.p(s1.ToUpper());
        U.p(s1.ToArray());
        U.p(s1.ToArray().GetType());
        U.p(s1.ToList());
        U.p(s1.ToList().GetType());

        U.p("--------------empty strings");
        string str = "hello";
        string? nullStr = null;
        string emptyStr = String.Empty;
        string tempStr = str + nullStr;
        Console.WriteLine(tempStr); // hello
        Console.WriteLine(emptyStr == nullStr); // False
        string newStr = emptyStr + nullStr; // creates a new empty string.

        Console.WriteLine(emptyStr.Length); // 0
        Console.WriteLine(newStr.Length); // 0
        //Console.WriteLine(nullStr.Length); //raises a NullReferenceException.

        System.Text.StringBuilder sb = new System.Text.StringBuilder("Rat: the ideal pet");
        sb[0] = 'C';
        U.p(sb); //Cat: the ideal pet
        sb.Append('!');
        U.p(sb.ToString()); //Cat: the ideal pet!

        U.p("-------Split");
        // the spaces make empty strings
        string phrase = "first   second  third.";
        string[] words = phrase.Split(' ');
        foreach (var word in words)
        {
            U.p($"<{word}>");
        }

        // String.Split can use multiple separator characters or strings. 
        string text = "one\ttwo three;:four,five six xsevenyeight[nine]ten";
        char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
        string[] words1 = text.Split(delimiterChars);
        U.p(words1);

        U.p("-----Split");
        string[] delimiterStrings = { "<", ">", "[", "]", "x", "y", "z" };
        string[] words2 = text.Split(delimiterStrings, System.StringSplitOptions.RemoveEmptyEntries); // need to specify these options
        U.p(words2);

        string theString = "Some Very Large String Here";
        U.p(theString);
        var array = theString.Split(' ');
        string rejoined = string.Join(" ", array);
        U.p(rejoined);
        string restOfArray = string.Join(" ", array.Skip(1)); // skip first element

        U.p("--------------------Replace");
        string source = "The mountains are behind the other mountains.";
        var replacement = source.Replace("mountains", "peaks");
        U.p(replacement);
        replacement = source.Replace(' ', '_');
        U.p(replacement);
        
        U.p("--------------------Remove");
        // Remove one substring from the middle of the string.
        string source1 = "Many mountains are behind many clouds today.";
        int numberOfCharsToRemove = "many ".Length;
        string result = source1.Remove(source1.IndexOf("many "), numberOfCharsToRemove);
        Console.WriteLine(source1);
        Console.WriteLine(result);

        U.p("--------------------Regex");
        // this code is strange, does 2 different things for the and many
        // Replace "the" or "The" with "many" or "Many".
        string source2 = "The mountains are still there behind the clouds today.";
        Console.WriteLine(source2);
        string replaceWith = "many ";
        // syntax: Regex.Replace(String, String, MatchEvaluator, RegexOptions) 
        source2 = System.Text.RegularExpressions.Regex.Replace(source2, "the\\s", ReplaceButKeepEventualCapitalization,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        Console.WriteLine(source2);

        string ReplaceButKeepEventualCapitalization(System.Text.RegularExpressions.Match matchExpression)
        {
            if (Char.IsUpper(matchExpression.Value[0])) // the first letter of the match is capitalized
            {
                System.Text.StringBuilder capitalizedReplacement = new System.Text.StringBuilder(replaceWith);
                capitalizedReplacement[0] = Char.ToUpper(capitalizedReplacement[0]);
                return capitalizedReplacement.ToString();
            }
            else
            {
                return replaceWith;
            }
        }

        U.p("---------------ToCharArray");
        string phrase1 = "The quick brown fox jumps over the fence";
        Console.WriteLine(phrase1);
        char[] chars = phrase1.ToCharArray();
        int index = phrase1.IndexOf("fox");
        chars[index++] = 'c';
        chars[index++] = 'a';
        chars[index] = 't';
        string updatedPhrase = new string(chars);
        U.p(updatedPhrase);

        U.p("----------- String comparison");
        string root = @"C:\users";
        string root2 = @"C:\Users";
        bool result1 = root.Equals(root2);
        U.p($"Ordinal comparison: <{root}> and <{root2}> are {(result1 ? "equal." : "not equal.")}");
        result1 = root.Equals(root2, StringComparison.Ordinal); // also see StringComparison.OrdinalIgnoreCase
        U.p($"Ordinal comparison: <{root}> and <{root2}> are {(result1 ? "equal." : "not equal.")}");
        result1 = root == root2;
        U.p($"== comparison: <{root}> and <{root2}> are {(result1 ? "equal" : "not equal")}");

        List<string> lines = new List<string>
            {@"c:\public\textfile.txt", @"c:\public\textFile.TXT", @"c:\public\Text.txt", @"c:\public\testfile2.txt"};
        U.p(lines);
        lines.Sort((left, right) => left.CompareTo(right));
        U.p("Sorted with CompareTo:");
        U.p(lines);
        lines.Sort(string.Compare); // or same: lines.Sort((left, right) => string.Compare(left, right));
        U.p("Sorted with Compare:");
        U.p(lines);
        
   }
}
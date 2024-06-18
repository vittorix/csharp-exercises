using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;
public class StringLINQ
{    
    public static void exec()
    {
       U.p("------Split select todictionary");
        var str2 = "key1:value1;key2:value2;key3:value3";
        var dict = str2.Split(';').Select(s => s.Split(':')).ToDictionary(key => key[0], value => value[1]);
        U.p(str2);
        U.p(dict);

        U.p("------Aggregate");
        string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };
        // gets the longest fruit name. in this case we don't need to pass an initial value (seed)
        // Return the final result as an upper case string.
        string longestName = fruits.Aggregate("", (current, next) => next.Length > current.Length ? next : current, fruit => fruit.ToUpper()); 
        Console.WriteLine("The fruit with the longest name is {0}.", longestName);     
   }
}
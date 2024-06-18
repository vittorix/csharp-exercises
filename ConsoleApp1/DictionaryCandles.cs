using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using Utilities;

class DictionaryCandles
{

    /*
     * Complete the 'birthdayCakeCandles' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY candles as parameter.
     */

    public static int birthdayCakeCandles(List<int> candles)
    {
        Dictionary<int, int> dictionary = new System.Collections.Generic.Dictionary<int, int>();
            int max=0;
        if(candles.Count>0)
            max=candles[0]; 
        candles.ForEach(n => {
            try{
                dictionary[n] = dictionary[n] + 1;
                if(dictionary[n] > dictionary[max]) 
                    max=n;
            }
            catch(Exception e) {
                dictionary[n] = 1;
            }
            U.p(n + " " + dictionary[n]);
        });
        U.p("-------");
        U.p(dictionary);
       return dictionary[max];
    }
}

class SolutionBirthdayCakeCandles
{
    public static void DictionaryCandlesMain(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());
        // List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

        List<int> candles= [18, 90, 90, 13, 90, 75, 90, 8, 90, 43];
        int result = DictionaryCandles.birthdayCakeCandles(candles);
        U.p(result);

        // textWriter.WriteLine(result);

        // textWriter.Flush();
        // textWriter.Close();
    }
}

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

class SortBigInts
{

    /*
     * Complete the 'bigSorting' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY unsorted as parameter.
     */

    public static List<string> bigSorting(List<string> unsorted)
    {
        return unsorted.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        // if you do the following normal sort, 5 will come last
        // return unsorted.OrderBy(a => a).ToList();
    }

}

class SolutionSortBigInts
{
    public static void MainSortBigInts(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        // int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> unsorted = new List<string>() {
            "31415926535897932384626433832795", "1", "3", "10", "3", "5"};

        // for (int i = 0; i < n; i++)
        // {
        //     string unsortedItem = Console.ReadLine();
        //     unsorted.Add(unsortedItem);
        // }

        List<string> result = SortBigInts.bigSorting(unsorted);
        U.p(result);

        // textWriter.WriteLine(String.Join("\n", result));
        // textWriter.Flush();
        // textWriter.Close();
    }
}

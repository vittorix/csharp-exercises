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

class MiniMaxSum
{

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {   
        long sum = 0;
        arr.ForEach(n => sum += n);
        arr.Sort();
        long min = sum - arr.Last();
        long max = sum - arr.First();
        Console.WriteLine(min + " " + max);
    }

}

class SolutionMiniMaxSum
{
    public static void MainMiniMaxSum(string[] args)
    {

        // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> arr =     [1,3,5,7,9];

        MiniMaxSum.miniMaxSum(arr);
    }
}

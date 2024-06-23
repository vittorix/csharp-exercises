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

public class MiniMaxSum
{
    public static void miniMaxSum(List<int> list)
    {   
        long sum = 0;
        U.pt(list, "list: ");
        list.ForEach(n => sum += n); // find the sum of all numbers
        U.pt(list, "list.ForEach(n => sum += n): ");
        
        list.Sort();
        U.pt(list, "sorted list: ");
        
        long min = sum - list.Last(); // sum - greatest of the 5 = sum of the first 4 numbers
        long max = sum - list.First(); // sum - smallest of the 5 = sum of the last 4 numbers
        U.p("min: " + min + " max: " + max);
    }
    public static void exec()
    {
        // https://www.hackerrank.com/challenges/mini-max-sum/problem
        // Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly
        // four of the five integers. Then print the respective minimum and maximum values 
        // as a single line of two space-separated long integers.
        // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        U.pst("miniMaxSum Hakerrank");
        List<int> arr =     [3,5,9,1,7];
        miniMaxSum(arr);
    }
}

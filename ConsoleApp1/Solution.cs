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

class PlusMinus
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        decimal ratioPositive = 0m;
        decimal ratioNegative = 0m;
        decimal ratioZero = 0m;
        arr.ForEach(n => {
            if(n<0)
                 ratioNegative++;
            else if (n>0)
                ratioPositive++;
            else ratioZero++;
        });
        // .ToString("0.000###") 
        // 0 means hide the zero
        // # means show the zero
        System.Console.WriteLine((ratioPositive/arr.Count).ToString("0.000000"));
        System.Console.WriteLine((ratioNegative/arr.Count).ToString("0.000000"));
        System.Console.WriteLine((ratioZero/arr.Count).ToString("0.000000"));
    }

}

class SolutionPlusMinus
{
    public static void MainPlusMinus(string[] args)
    {
        // int n = Convert.ToInt32(Console.ReadLine().Trim());

        // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> arr =[1, 32, -1, -1, 2, 0];

        PlusMinus.plusMinus(arr);
    }
}

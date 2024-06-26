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

class Triangle
{

    /*
     * Complete the 'staircase' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void staircase(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.Write(" ");
            }
            for (int k = 0; k < i + 1; k++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
    }

    public static void exec()
    {
        U.ps("Triangle");
        // int n = Convert.ToInt32(Console.ReadLine().Trim());
        Triangle.staircase(6);
    }
}

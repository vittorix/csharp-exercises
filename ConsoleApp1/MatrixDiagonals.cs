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

class MatrixDiagonals
{

    // Given a square matrix, calculate the absolute difference between the sums of its diagonals.
    /*
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    // se also MultidimensionArray.cs
    public static int diagonalDifference(List<List<int>> list)
    {
        list = new List<List<int>> {
            new List<int>{1,2,3},
            new List<int>{1,2,3},
            new List<int>{1,2,3}
        };
        list[0][0] = 11;
        list[0][1] = 2;
        list[0][2] = 4;
        list[1][0] = 4;
        list[1][1] = 5;
        list[1][2] = 6;
        list[2][0] = 10;
        list[2][1] = 8;
        list[2][2] = -12;

        U.pll(list, "list:");

        int diag1 = 0;
        int diag2 = 0;
        U.p(list.Count);
        for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list.Count; j++)
            {
                U.p(i + " " + j);
                if (i == j)
                {
                    U.p("   " + i + " " + j + " <1>" + list[i][j]);
                    diag1 += list[i][j];
                }
                if (i + j == list.Count - 1)
                {
                    U.p("   " + i + " " + j + " <2>" + list[i][j]);
                    diag2 += list[i][j];
                }
            }
        return Math.Abs(diag1 - diag2);
    }
}
class Solution2
{
    public static void Main1(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        // for (int i = 0; i < n; i++)
        // {
        //     arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        // }

        int result = MatrixDiagonals.diagonalDifference(arr);
        U.p(result);

        // textWriter.WriteLine(result);

        // textWriter.Flush();
        // textWriter.Close();
    }
}

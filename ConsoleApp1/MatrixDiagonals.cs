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

    public static int diagonalDifference(List<List<int>> arr){
        arr = new List<List<int>> {
            new List<int>{1,2,3}, 
            new List<int>{1,2,3}, 
            new List<int>{1,2,3}
        };
         arr[0][0] = 11;
        arr[0][1] = 2;
        arr[0][2] = 4;
        arr[1][0] = 4;
        arr[1][1] = 5;
        arr[1][2] = 6;
        arr[2][0] = 10;
        arr[2][1] = 8;
        arr[2][2] = -12;

        int diag1 =0;
        int diag2 =0;
        U.p(arr.Count);
        for(int i=0; i<arr.Count ;i++)
            for(int j=0; j < arr.Count; j++){
                U.p(i + " " + j);
                if(i==j) {
                    U.p("   " + i + " " + j + " <1>" + arr[i][j]);
                    diag1 += arr[i][j];
                }
                if(i+j == arr.Count - 1) {
                    U.p("   " + i + " " + j + " <2>" + arr[i][j]);
                    diag2 += arr[i][j];
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

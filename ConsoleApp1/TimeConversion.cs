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

class TimeConversion
{

    /*
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    // convers time to military time 24h
    public static string timeConversion(string s)
    {
        DateTime dateTime = DateTime.ParseExact(s, "hh:mm:sstt",
        System.Globalization.CultureInfo.InvariantCulture);
        return dateTime.ToString("HH:mm:ss");
        // 19:05:45
    }

}

class SolutionTimeConversion
{
    public static void TimeConversionMain(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // string s = Console.ReadLine();

        string result = TimeConversion.timeConversion("07:05:45PM");
        U.p(result);
        // textWriter.WriteLine(result);

        // textWriter.Flush();
        // textWriter.Close();
    }
}

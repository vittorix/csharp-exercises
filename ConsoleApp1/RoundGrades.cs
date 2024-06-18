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

class RoundGrades
{

    /*
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> newGrades = [];
        HashSet<int> multiples =  new HashSet<int>(){40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100};
        grades.ForEach(grade => {
            if (!multiples.Contains(grade) && grade > 37){
                char first = grade.ToString()[0];
                char last = grade.ToString()[1];
                if(last == '3' || last == '4') 
                    grade = Int32.Parse(first + "5");
                else if (last == '8' || last == '9')
                    grade = Int32.Parse((Int32.Parse(first.ToString()) + 1) + "0");
            }
            newGrades.Add(grade);
        });
        return newGrades;
    }

}

class RoundGradesSolution
{
    public static void RoundGradesMain(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>() {73, 67, 38, 33};

        // for (int i = 0; i < gradesCount; i++)
        // {
        //     int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
        //     grades.Add(gradesItem);
        // }

        List<int> result = RoundGrades.gradingStudents(grades);
        U.p(result);

        // textWriter.WriteLine(String.Join("\n", result));

        // textWriter.Flush();
        // textWriter.Close();
    }
}

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

public class Element
{
    public required string Symbol { get; init; }
    public required string Name { get; init; }
    public required int AtomicNumber { get; init; }
}

public class LINQquery {
    public static void exec() {
        U.pst("LINQquery");

        U.p("Enter a bunch of space separated integers");
        // commented to do dotnet run > output.txt
        // List<int> numbers = Console.ReadLine().TrimEnd().Split(' ').ToList()
        //     .Select(stringsTemp => Convert.ToInt32(stringsTemp)).ToList();
                List<int> numbers = [4, 67, 76, 93, 0, 5]; 
        U.pt(numbers, "you entered: ");
        U.ps();

        List<Element> elements = new() {
            { new(){ Symbol="K", Name="Potassium", AtomicNumber=19}},
            { new(){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            { new(){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            { new(){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };
    
        // System.Linq.IOrderedEnumerable<Element> subset = from theElement in elements
        var subset = from theElement in elements
                    where theElement.AtomicNumber < 22
                    orderby theElement.Name
                    select theElement;

        //  Calcium 20
        //  Potassium 19
        //  Scandium 21
        foreach (Element theElement in subset)
            Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
        
        U.ps();
        string[] fourStrings = ["a", "b", "c"];
        int[] tenNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        IEnumerable<string> query = tenNumbers.Select(n => "+" + n).Concat(fourStrings.Select(n => n + "+"));
        U.pt(query, "10 numbers concatenated 4 strings: ");

    }
}

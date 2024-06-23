using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Collections.Immutable;
using System.Linq;

public class EnumerableMethods
{    
    public static int Sum (IEnumerable<int> values) => values.Sum();
                
    public static void exec()
    {
        U.ps("Enumerable Methods");

        int[] fourNumbers = [1, 2, 3, 4];
        U.p("sum 4n: " + Sum(fourNumbers));
        U.p("sum 4n: " + U.sum(fourNumbers));
        // int[] nums = new int[]{12, 34};
        int[] tenNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        U.p("sum 10n: " + System.Linq.Enumerable.Sum(tenNumbers));
        U.p("avg 10n: " + System.Linq.Enumerable.Average(tenNumbers));
        
        U.ps("concatenate then join an array of ints into a string");
        var together = fourNumbers.Concat(tenNumbers);
        U.pt(together, "4n concat 10n: ");
        U.p("concat 10n: " + string.Join(' ', System.Linq.Enumerable.Concat(tenNumbers, fourNumbers)));
        IEnumerable<string> query = tenNumbers.Select(n => "+" + n).Concat(fourNumbers.Select(n => n + "+"));
        U.pt(query);

        U.ps("Distinct");
        U.pt(together.Distinct(), "together.Distinct(): "); // 10 numbers again
        
        U.ps("Where");
        U.pt(together.Where(n => n > 5), ".Where(n => n > 5): ");


        U.ps("even numbers");
        U.pt(together.Select(n => n % 2 ==0 ? n : Int32.MaxValue).Where(n => n < Int32.MaxValue), ".Select() even: ");
        U.pt(together.Select(n => n % 2 ==0), ".Select().Where() true if even: "); // true or false
        U.pt(together.Where(n => n % 2 ==0), ".Where() even: ");
        
        IEnumerable<int> ints = together.OfType<int>(); // return only the elements that can safely be cast to int
        U.pt(ints, "together.OfType<int>()");
        ints = together.Cast<int>(); // try to cast all the elements into type x.
        U.pt(ints, "together.Cast<int>()");






    }
}
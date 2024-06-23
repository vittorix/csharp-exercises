using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Collections.Immutable;
using System.Linq;

public class CollectionExpressions
{    
        private static readonly ImmutableArray<string> months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        // property with expression body:
        public IEnumerable<int> MaxDays => [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
                
    public static void exec()
    {
        U.pst("collection expressions");
        int[] nums = [1, 2, 3, 4]; // [1, 2, 3, 4] is a collection expression
        U.p("sum first 4 numbers: " + U.sum(nums));

        List<int> list = [1,2,3,4,5,6];
        // Ranges can be used on arrays and span types to extract the subset of a sequence by using the .. (two dots) operator.
        List<int> list1 = [.. list]; 
        U.pt(list1, "copied: ");

        U.ps("Span, Slice");
        // int[] tenNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] tenNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        U.pt(tenNumbers);
        Span<int> numbersSpan = tenNumbers.AsSpan();
        Span<int> slice = numbersSpan.Slice(3, 5); // gets 5 numbers starting from index 3 (so from 4 to 8) 
        U.pt(slice.ToArray(), "Slice(3, 5): ");
        
        U.ps("Range, Join, Hat operator");
        // a range goes from element[firstindex] to last index - 1
        int[] rangeNumbers = tenNumbers[3..6]; // tn[3..6] = [tn[3], tn[4], tn[5]] = [4, 5, 6]
        U.pt(rangeNumbers, "tenNumbers[3..6]: ");
        string numbersStr = string.Join(", ", rangeNumbers);        
        U.p("joined: " + numbersStr);

        // tn[4..^0] goes from tn[4] to the last (5 to 10)
        U.pt(tenNumbers[4..^0], "tenNumbers[4..^0]: ");
        // tn[4..^1] goes from tn[4] to one to last (5 to 9)
        U.pt(tenNumbers[4..^1], "tenNumbers[4..^1]: ");


   }
}
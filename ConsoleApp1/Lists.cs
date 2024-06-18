using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class Lists
{    
    public static void exec()
    {
        List<int> list = [1,2,3,4,5,6];
        U.pt(list);
        List<int> reversed = U.reverse(list);
        U.pt(reversed);

        U.p("----");

        List<string> list1 = new List<string>() { "geeks", "31", "a", "1",  "5", "Geek123", "GeeksforGeeks"}; 
        list.ForEach(a => {
            Console.Write("\t");
            Console.Write(a);
        });

        list.ForEach(s => U.p("s=" + s));

        // also: RemoveAll(T) and RemoveAt(index) and RemoveRange(Int32, Int32)
        Console.WriteLine();
        list1.Remove("Geek123"); 
        U.pt(list1);
        
        list1.Add("Geek123");
        U.pt(list1);

        // init list with values from other list
        List<string> list2 = new List<string>(list1);

        // copy list to another
        List<string> list3 = list1.ToList();

        // add elements from list into another
        list3.AddRange(list2);

        // copy list to array
        string[] array = new string[list1.Count];
        list1.CopyTo(array);

        list3.Clear();

        U.p("--------");
        list2.Sort();
        U.pt(list2);
        list2.Sort((a, b) => a.CompareTo(b)); // doesn't do any sorting
        U.pt(list2);
        list2.Sort((a, b) => b.CompareTo(a)); // reverses the list
        U.pt(list2);
   }
}
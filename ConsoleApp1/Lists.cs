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
        U.ps("Lists");
        U.ps("Reverse");
        List<int> list = [1,2,3,4,5,6];
        U.pt(list);
        List<int> reversed = U.reverse(list);
        U.pt(reversed);
        reversed.Reverse();
        U.pt(reversed);

        U.ps("ForEach");
        list.ForEach(a => Console.Write("\t" + a));
        U.p();

        U.ps("First, Last, direct access---");
        // List<string> list1 = new List<string>() { "geeks", "31", "a", "1",  "5", "Geek123", "GeeksforGeeks"}; 
        List<string> list1 = ["geeks", "31", "a", "1",  "5", "Geek123", "GeeksforGeeks"]; 
        U.pt(list1);
        U.p("first: " + list1.First());
        U.p("last: " + list1.Last());
        U.p("second: " + list1[1]);
        
        U.ps("removal---");
        // also: RemoveAll(T) and RemoveAt(index) and RemoveRange(Int32, Int32)
        Console.WriteLine();
        list1.Remove("Geek123"); 
        U.pt(list1);
        list1.Add("Geek123");
        U.pt(list1);

        U.ps("CopyTo, initialization, AddRange, Clear---");
        // copy list to array
        string[] array = new string[list1.Count];
        list1.CopyTo(array);
        // copy list to another
        List<string> list3 = [.. list1]; // .. spread operator 
        list3 = list1.ToList();

        // init list with values from other list
        List<string> list2 = new List<string>(list1);
        
        // add elements from list into another
        list3.AddRange(list2);

        list3.Clear();
        Console.Write("Cleard list: ");
        U.pt(list3);

        U.ps("Sort & reverse sort");
        list2.Sort();
        U.pt(list2);
        list2.Sort((a, b) => a.CompareTo(b)); // doesn't do any sorting
        U.pt(list2);
        list2.Sort((a, b) => b.CompareTo(a)); // reverses the list
        U.pt(list2);

        // to be fixed
        // U.ps("Sort numerically (by length, then alphabetically)");
        // List<string> orderNumerically = ["aaaaaaaaa", "31a", "a", "1",  "5", "0", "AA11", "09837640983743981374"];
        // // orderNumerically.OrderBy(x => r.Next()); // scramble the list
        // // Random r = new Random();
        // U.pt(orderNumerically);
        // orderNumerically.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        // U.pt(orderNumerically);
        // // orderNumerically.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        // // U.pt(orderNumerically);

        U.ps("binary search");
        List<string> list4 = list1.ToList();
        U.pt(list4);
        U.p("5 found at position: " + list4.BinarySearch("5"));
        
        U.ps("convertAll");
        List<long> longs = list.ConvertAll(i => (long) i);       
        U.pt(longs, "longs: ");

        U.ps("conversion with Select and ToList");
        longs = [];
        longs = list.Select(n => (long) n).ToList();
        U.pt(longs, "longs: ");

        U.ps("Exists, Contains, Find");
        U.p("4L exists in the list: " + longs.Exists(x => x == 4L));
        U.p("list contains 4L: " + longs.Contains(4L));
        U.p("found element: " + longs.Find(x => x == 4L));
        longs.Add(4L);
        U.pt(longs);
        List<long> occurrences = longs.FindAll(x => x == 4L);
        U.p("found all occurrences of element 4L:");
        U.p(occurrences);

        U.ps("Insert");
        longs.Insert(0, 32L); // insert at beginning
        List<long> longs1 = longs.Prepend(-1000L).Append(1000L).ToList(); // create new list with 2 new elements
        U.pt(longs1);

        U.ps("InsertRange");
        longs1.InsertRange(4, [121, 122, 123]);
        U.pt(longs1);
        U.p("Found 123L at index: " + longs1.FindIndex(3, 7, x => x == 123L));

        U.ps("AddRange");
        var employees = new List<Employee>();
        List<Employee> employees1 = [new Employee { Name = "Pippo", Id = 32 }, 
            new Employee { Name = "Pluto", Id = 33 }];
        employees.AddRange(new Employee[] { new Employee { Name = "Frank", Id = 2 },
                                            new Employee { Name = "Jill", Id = 3 },
                                            new Employee { Name = "Dave", Id = 5 },
                                            new Employee { Name = "Jack", Id = 8 },
                                            new Employee { Name = "Judith", Id = 12 },
                                            new Employee { Name = "Robert", Id = 14 },
                                            new Employee { Name = "Adam", Id = 1 } } );
        employees.Sort();
        U.pt(employees.Select(x => x.Name), "employees: ");

        employees.AddRange(employees1);
        employees.Sort();
        U.pt(employees.Select(x => x.Name), "employees + employees1: ");

        U.ps("FindIndex");
        var es = new EmployeeSearch("J");
        Console.WriteLine("'J' starts at index {0}",
                            employees.FindIndex(0, 6, es.StartsWith));

        es = new EmployeeSearch("Ju");
        Console.WriteLine("'Ju' starts at index {0}",
                            employees.FindIndex(0, employees.Count - 1, es.StartsWith));



   }
}
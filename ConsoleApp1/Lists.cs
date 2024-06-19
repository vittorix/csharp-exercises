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
        U.p("----Reverse----");
        List<int> list = [1,2,3,4,5,6];
        U.pt(list);
        List<int> reversed = U.reverse(list);
        U.pt(reversed);
        reversed.Reverse();
        U.pt(reversed);

        U.p("----ForEach---");
        List<string> list1 = new List<string>() { "geeks", "31", "a", "1",  "5", "Geek123", "GeeksforGeeks"}; 
        list.ForEach(a => {
            Console.Write("\t");
            Console.Write(a);
        });
        U.p();

        list.ForEach(s => U.p("s=" + s));

        U.p("----First, Last, direct access---");
        U.pt(list1);
        U.p("first: " + list1.First());
        U.p("last: " + list1.Last());
        U.p("second: " + list1[1]);
        
        U.p("----removal---");
        // also: RemoveAll(T) and RemoveAt(index) and RemoveRange(Int32, Int32)
        Console.WriteLine();
        list1.Remove("Geek123"); 
        U.pt(list1);
        list1.Add("Geek123");
        U.pt(list1);

        U.p("----Copy, AddRange, initialization, Clear---");
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

        U.p("------Sort & reverse sort-----");
        list2.Sort();
        U.pt(list2);
        list2.Sort((a, b) => a.CompareTo(b)); // doesn't do any sorting
        U.pt(list2);
        list2.Sort((a, b) => b.CompareTo(a)); // reverses the list
        U.pt(list2);

        // to be fixed
        // U.p("-----Sort numerically (by length, then alphabetically)");
        // List<string> orderNumerically = ["aaaaaaaaa", "31a", "a", "1",  "5", "0", "AA11", "09837640983743981374"];
        // // orderNumerically.OrderBy(x => r.Next()); // scramble the list
        // // Random r = new Random();
        // U.pt(orderNumerically);
        // orderNumerically.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        // U.pt(orderNumerically);
        // // orderNumerically.OrderBy(a => a.Length).ThenBy(a => a).ToList();
        // // U.pt(orderNumerically);

        U.p("----binary search----");
        List<string> list4 = list1.ToList();
        U.pt(list4);
        U.p("5 found at position: " + list4.BinarySearch("5"));
        
        U.p("----convertAll----");
        List<long> longs = list.ConvertAll(i => (long) i);       
        U.pt(longs);

        U.p("----Exists, Contains, Find----");
        U.p("4L exists in the list: " + longs.Exists(x => x == 4L));
        U.p("list contains 4L: " + longs.Contains(4L));
        U.p("found element: " + longs.Find(x => x == 4L));
        longs.Add(4L);
        U.pt(longs);
        List<long> occurrences = longs.FindAll(x => x == 4L);
        U.p("found all occurrences of element 4L:");
        U.p(occurrences);

        U.p("----Insert----");
        longs.Insert(0, 32L); // insert at beginning
        List<long> longs1 = longs.Prepend(-1000L).Append(1000L).ToList(); // create new list with 2 new elements
        U.pt(longs1);

        U.p("----AddRange, InsertRange, FindIndex----");
        var employees = new List<Employee>();
        employees.AddRange(new Employee[] { new Employee { Name = "Frank", Id = 2 },
                                            new Employee { Name = "Jill", Id = 3 },
                                            new Employee { Name = "Dave", Id = 5 },
                                            new Employee { Name = "Jack", Id = 8 },
                                            new Employee { Name = "Judith", Id = 12 },
                                            new Employee { Name = "Robert", Id = 14 },
                                            new Employee { Name = "Adam", Id = 1 } } );
        employees.Sort();
        U.pt(employees.Select(x => x.Name));

        var es = new EmployeeSearch("J");
        Console.WriteLine("'J' starts at index {0}",
                            employees.FindIndex(0, 6, es.StartsWith));

        es = new EmployeeSearch("Ju");
        Console.WriteLine("'Ju' starts at index {0}",
                            employees.FindIndex(0, employees.Count - 1, es.StartsWith));

        longs1.InsertRange(4, [121, 122, 123]);
        U.pt(longs1);
        U.p("Found 123L at index: " + longs1.FindIndex(3, 7, x => x == 123L));



   }
}
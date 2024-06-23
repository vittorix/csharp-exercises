using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Collections.Immutable;
using System.Linq;

public class EnumerableLINQ
{    
    public static int Sum (IEnumerable<int> values) => values.Sum();
                
    public class PhoneNumber(string Number)
    {
        // primary constructor
        public string Number { get; set; } = Number;
    }

    public class Person(string Name, List<EnumerableLINQ.PhoneNumber> PhoneNumbers)
    {
        public string Name { get; set; } = Name;
        public List<PhoneNumber> PhoneNumbers { get; set; } = PhoneNumbers;

    }

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
        U.pt(together.ToList().FindAll(n => n % 2 ==0), ".FindAll() even: ");
        
        U.ps("OfType, Cast");
        IEnumerable<int> ints = together.OfType<int>(); // return only the elements that can safely be cast to int
        U.pt(ints, "together.OfType<int>()");
        ints = together.Cast<int>(); // try to cast all the elements into type x.
        U.pt(ints, "together.Cast<int>()");
    
        U.p("together.ElementAt(6): " + tenNumbers.ElementAt(6).ToString());
        U.pt(together.Except(fourNumbers), "together.Except(fourNumbers): "); // 5 6 7 8 9 10
        U.pt(tenNumbers.Intersect(fourNumbers), "tenNumbers.Intersect(fourNumbers): "); // 1 2 3 4
        U.pt(tenNumbers.OrderBy(x => x), "tenNumbers.OrderBy(x => x): "); // 1 to 10
        U.pt(tenNumbers.OrderBy(x => x + 1), "tenNumbers.OrderBy(x => x + 1): "); // 1 to 10
        U.pt(tenNumbers.OrderByDescending(x => x), "tenNumbers.OrderByDescending(x => x): "); // reverse 10 to 1
        
        U.ps("One to many relationship");
        IEnumerable<Person> people = new List<Person>();
        List<PhoneNumber> vixNumbers = [new PhoneNumber("123 456 7890"), new PhoneNumber("321 312 4567")];
        people = people.Append(new Person("Vix", vixNumbers));
        Person vix = people.ToArray()[0];
        PhoneNumber number1 = vix.PhoneNumbers[0];
        PhoneNumber number2 = vix.PhoneNumbers[1];
        U.p( "Name: " + vix.Name + " Phone Numbers: " + number1.Number + ", " + number2.Number);

        U.ps("Select gets a list of lists of phone numbers");
        // IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);
        var phoneLists = people.Select(p => p.PhoneNumbers);
        U.p("number1: " + phoneLists.First().First().Number);
        U.p("number2: " + phoneLists.First().ElementAt(1).Number);
        foreach(List<PhoneNumber> phoneNumber in phoneLists) {
            U.p("number1: " + phoneNumber[0].Number);
            U.p("number2: " + phoneNumber[1].Number);
        }

        U.ps("SelectMany flattens it to just a list of phone numbers");
        IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);
        foreach(PhoneNumber phoneNumber in phoneNumbers) {
            U.p("number: " + phoneNumber.Number);
        }
        
        U.ps("SelectMany include parents' data");
        // And to include data from the parent in the result: 
        // pass an expression to the second parameter (resultSelector) in the overload:
        var directory = people.SelectMany(p => p.PhoneNumbers, 
                        (parent, child) => new {parent.Name, child.Number});
        U.pt(directory, "directory: ");





    }
}
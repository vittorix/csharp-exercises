using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;
public class Records
{
    int age { get; set; }
    public record Person(string name, int age, bool naughty);

    public static void exec()
    {
        U.pst("Records");

        Person vix = new Person("Vix", 43, true);
        U.p(vix);
        Person vix1 = new Person("Vix", 43, true);
        U.p(vix1);
        // records are compared by their properties
        U.p(vix == vix1); // True
        Person fia = new Person("Fia", 5, false);
        U.p(fia);
        U.p(vix == fia);
        Person Aex = fia with { name = "Axel", age = 9 };
        U.p(Aex);
    }
}
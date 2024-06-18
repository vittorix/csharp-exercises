using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;
public class Records 
{    
    public record Person(string name, int age);

    public static void exec()
    {
        Person vix = new Person("Vix", 53);
        U.p(vix);
        Person vix1 = new Person("Vix", 53);
        U.p(vix1);
        // records are compared by their properties
        U.p(vix==vix1); // True
        Person fia = new Person("Fia", 6);
        U.p(fia);
        U.p(vix==fia);
        Person Aex = fia with { name = "Aex" };
        U.p(Aex);
    }
}
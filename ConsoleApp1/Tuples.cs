using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class Tuples
{
    public static void exec()
    {
        U.pst("Tuples");

        var t2 = Tuple.Create("Vix", 5);
        U.p("t2.Item1: " + t2.Item1);
        // max 8 elements in a Tuple

        var t8 = Tuple.Create(13, "Vix", 67, 89.90, 'g', 39939, 10, "Vix");
        U.p("t8.Item2: " + t8.Item2);
        //  an 8-tuple has a Rest property to retrieve last element
        U.p("Rest of t8: " + t8.Rest);

        // _ is a discard, placeholder variable that are intentionally unused
        // jh is type: System.ValueTuple`4[System.String,System.String,System.Int32,System.Int32]
        _ = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);

    }
}
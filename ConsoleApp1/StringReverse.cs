using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class StringReverse
{
    public static void exec()
    {
        U.pst("StringReverse");

        string s = "12345678";
        U.p(s);
        string reversed = U.reverse(s);
        U.p("======");
        U.p(reversed);
    }
}
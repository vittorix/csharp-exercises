using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class Searches 
{    
    public static void exec()
    {
        // works only with the target = 3, it causes infinite loop otherwise. implementation is incorrect
        int[] array = [1,2,3,4,5];
        int position = U.searchBinary(array, 3, 0, array.Length-1);
        U.p("Found at position: " + position);
   }
}
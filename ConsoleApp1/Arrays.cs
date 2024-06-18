using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;
public class Arrays 
{    
    public static void exec() {
        int[] ints = [1, 2, 3, 4, 5, 6];
        object[] objs = ["26", 27, 28, 29, 30];
        U.pt(ints);
        U.pt(objs);
        // Copies the first two elements from the integer array to the Object array.
        Array.Copy(ints, objs, 2);
        U.pt(objs);
        // Copies the last two elements from the Object array to the integer array.
        Array.Copy(objs, 3, ints, 4, 2); 
        // the one to last index of an array (in this case 3 and 4) can also be calculated: array.GetUpperBound(0) - 1 or GetLength() - 2
        U.pt(ints);

        U.p("----------");
        IEnumerator enumerator = ints.GetEnumerator();
        while (enumerator.MoveNext()) {
            U.p("\t" + enumerator.Current.ToString());
        }
    }
}
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using Utilities;

class SortedDictionary
{
    public static void exec()
    {
        // collection of key/value pairs sorted on the key
        // use HashTable if unsorted
        U.ps("SortedDictionary");
        SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
        sortedDictionary.Add("Element C", 200);
        sortedDictionary.Add("Element A", 200);
        sortedDictionary.Add("Element V", 100);
        U.p(sortedDictionary);
    }
}

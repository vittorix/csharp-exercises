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

class HashTableDate
{
    public static void exec()
    {
        // collection of key/value pairs organized on the hashcode of the key
        // if sorted, use SortedDictionary
        U.p("-------HashTable");
        Hashtable table = new Hashtable();
        table.Add(1, 2);
        table.Add("new DateTime()", new DateTime());           // 1/1/0001 12:00:00 AM
        table.Add("new DateTime().Date", new DateTime().Date); // 1/1/0001 12:00:00 AM
        table.Add("new DateTime().Second", new DateTime().Second); // 0
        table.Add("DateTime.Now", DateTime.Now);               // 6/20/2024 2:30:16 PM
        U.p(table);
    }
}

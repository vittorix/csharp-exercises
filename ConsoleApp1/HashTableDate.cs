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
using System.Collections.ObjectModel;

class HashTableDate
{
    public static void exec()
    {
        U.pst("HashTableDate");

        // DEPRECATED!!! USE DICTIONARY
        // collection of key/value pairs organized on the hashcode of the key
        // if sorted, use SortedDictionary
        U.ps("HashTable DEPRECATED!!! USE DICTIONARY");
        Hashtable table = new Hashtable();
        table.Add(1, 2);
        table.Add("new DateTime()", new DateTime());           // 1/1/0001 12:00:00 AM
        table.Add("new DateTime().Date", new DateTime().Date); // 1/1/0001 12:00:00 AM
        table.Add("new DateTime().Second", new DateTime().Second); // 0
        table.Add("DateTime.Now", DateTime.Now);               // 6/20/2024 2:30:16 PM

        DateTime dt = new(2021, 12, 31, 18, 30, 0);
        table.Add("dt.ToString(\"d\"): ", dt.ToString("d"));  // 12/31/2021
        table.Add("dt.ToString(\"F\"): ", dt.ToString("F"));  // Friday, December 31, 2021 6:30:00 PM
        U.p(table);

        Hashtable table2 = new Hashtable() {{U.newId(), "hello"}, {U.newId(), 234},
                 {U.newId(), 230.45}, {U.newId(), null}};
        U.ps();
        foreach (DictionaryEntry entry in table2)
            U.p($"entry: {entry} \t key: {entry.Key} \t value: {entry.Value}");
        U.ps();
        foreach (string key in table2.Keys)
            U.p($"key: {key} \t value: {table2[key]}");
        U.ps();
    }
}

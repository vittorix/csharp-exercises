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

class DictionarySortedList
{
    public static void exec()
    {
        U.p("-------Dictionary");
        var dictionary = new Dictionary<int, string>() {{1, "c"}, {3, "a"}, {2, "b"}};
        U.p(dictionary);
        U.p("-------");
        var sortedDictionary = dictionary.OrderBy(x => x.Key);
        U.p(sortedDictionary);
        U.p("-------");
        var reversedDictionary = dictionary.OrderByDescending(x => x.Key);
        U.p(reversedDictionary);
        U.p("-------");
        var sortedByValue = dictionary.OrderBy(x => x.Value);
        U.p(sortedByValue);

        U.p("-------SortedList");
        SortedList sList = new SortedList(){{2, "sono"}, {1, "io"}, {3, "Vix"}};
        U.pt(sList);
        string sentence ="";
        foreach (string s in sList.Values) {
            sentence += s + " ";
        };
        U.p(sentence);
    }
}

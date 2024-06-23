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

class RandomNumbers
{
    public static void exec()
    {
        U.pst("RandomNumbers");
        List<int> list = [];
        int n = 100;
        int min = 45;
        int max = 75;
        Random random = new Random();

        for (int i=0; i<n; i++) {
            list.Add(random.Next(min, max + 1));
        }
        U.pt(list);
    }
}

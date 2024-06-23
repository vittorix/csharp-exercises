using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class Threads
{    
    static void Worker()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("       Worker. i: " + i);
            Thread.Sleep(100);
        }
    }
    public static void exec()
    {
        U.pst("Threads");

        Thread t = new Thread(Worker);
        t.Start();

        for (int j = 0; j < 10; j++) {
            Console.WriteLine("Main. j: " + j);
            Thread.Sleep(100);
        }
 
        // wait for the worker thread to complete
        t.Join();
        Console.WriteLine("Done");
    }
}
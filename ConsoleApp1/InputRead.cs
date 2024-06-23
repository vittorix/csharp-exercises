using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class InputRead 
{    
    public void exec(string[] args)
    {
        U.pst("InputRead");

        // reads a line from input and converts it into a list of strings
        List<int> strings = Console.ReadLine().TrimEnd().Split(' ').ToList()
            .Select(stringsTemp => Convert.ToInt32(stringsTemp)).ToList();

        try{
            int? n =0;
            foreach(var arg in args){
                Console.WriteLine("arg: "+ arg);
            }
            if(args.Length != 0){
                n = Int32.Parse(args[0]);
            } 
            else {
                Console.WriteLine("insert number: ");
                string? input = Console.ReadLine();
                n = Int32.Parse(input);
            }
            Console.WriteLine("n: " + n);
        }
        catch(Exception exception){
               Console.WriteLine("Please enter a number! " + exception.ToString());
        }
   }
}
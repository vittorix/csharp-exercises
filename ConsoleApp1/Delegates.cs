using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
public class Delegates
{    
    public static void DoWork(Action<string> callback) {
        callback("Example delegate 1");
    }

    public delegate void CallbackDelegate(string message);

 	public static void FunctionToCall(string message) {
        Console.WriteLine(message);
	}

	public static void exec() {
        DoWork((result) => Console.WriteLine(result));
        DoWork(Console.WriteLine); // This also works

        U.p("---------");
        CallbackDelegate delegateCallBack2 = new CallbackDelegate(FunctionToCall);
        delegateCallBack2("Example delegate 2");

        U.p("---------");

        Action<string> actionExample1 = x => Console.WriteLine($"Action: {x}");
        actionExample1("Encapsulates a method that has a single parameter and does not return a value");

        Action<string, string> actionExample2 = (x, y) => Console.WriteLine($"Action: {x} {y}");
        actionExample2("can have also", "2 methods");

        Func<string, int> convertToInt = x => Convert.ToInt32(x);
        Console.WriteLine($"The value is {convertToInt("1")}");

        Func<int, int, int> sum = (x, y) => x + y;
        Console.WriteLine($"The sum is {sum(1, 2)}");
    }
}
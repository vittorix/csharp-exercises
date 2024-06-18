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
    }
}
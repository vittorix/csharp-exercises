using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;

// this struct is made readonly with the addition of readonly and init(). 
// struct: in stack memory. immutable. they group together value data
public readonly struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double X { get; init; }
    public double Y { get; init; }

    // you can use readonly on functions too
    public readonly double area()
    {
        return X * Y;
    }
    public override string ToString() => $"(x={X}, y{Y}, area={area()})";
}

public class Structs
{
    public static void exec()
    {
        U.pst("Structs");
        Coords coords = new Coords(10, 12);
        U.p(coords);
    }
}
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;

public class EnumSwitch {

    public enum Person {
        Newborn, Child, Adult, Senior
    }

    // switch expression to evaluate a single expression from a list of candidate expressions based 
    // on a pattern match with an input expression
    public static string introduceYourself(Person person) => person switch
    {
        Person.Newborn => $"Hi, I'm a {Person.Newborn} of age 0-1",
        Person.Child => $"Hi, I'm a {Person.Child} of age 2-18",
        Person.Adult => $"Hi, I'm a {Person.Adult} of age 18-65",
        Person.Senior => $"Hi, I'm a {Person.Senior} of age > 65", 
        _ => throw new NotImplementedException()
    };

    public static void exec (){
        U.pst("EnumSwitch");

        Person person1 = Person.Adult;
        switch (person1){
            case Person.Newborn: U.p("0-1");    break;
            case Person.Adult:    U.p("18-65");    break;
        }

        Person person2 = new();
        switch (person2){
            case < Person.Child: U.p("p2: 0-1");    break;
            case > Person.Adult: U.p("p2: 18-100");    break;
            default: U.p("p2: I don't know age");    break;
        }

        Person person3 = Person.Senior;
        switch (person3){
            default: U.p("I don't know age");    break;
            case Person.Newborn: U.p(introduceYourself(Person.Newborn));    break;
            case Person.Adult: U.p(introduceYourself(Person.Newborn));    break;
            case Person.Senior: U.p(introduceYourself(Person.Senior));    break;
        }        
    }
}
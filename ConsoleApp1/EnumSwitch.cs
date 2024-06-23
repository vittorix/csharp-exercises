using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;

public class EnumSwitch {
    enum Person {
        Newborn, Child, Adult, Senior
    }

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
            case Person.Newborn: U.p("0-1");    break;
            case Person.Adult: U.p("18-65");    break;
        }
    }
}
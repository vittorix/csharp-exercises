using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;

interface Animal {
    void move(int steps);
    void talk(string message);
    void introduceSelf();
}

public class Dog : Animal {
    string name {get; set;}
    public Dog(string name) {
        this.name = name;
    }

    public void move(int steps) {
        U.p($"I moved {steps} steps.");
    }
    public void talk(string message) {
        U.p($"Wooffing {message} loudly.");
    }
    public void introduceSelf() {
        U.p($"Hi I'm {name}, I'm a {this.GetType()}");
    }
}
public class Interfaces 
{    
    public static void exec() {
        Animal cassie = new Dog("Cassie");
        cassie.introduceSelf();
        cassie.move(5);
        cassie.talk("I'M HUNGRY");
    }
}
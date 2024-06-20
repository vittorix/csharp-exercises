using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Utilities;
using System.Linq;

public class Animal: ComparerAnimal
{
    public int Age {get; set;}
}

public class Dog : Animal, IAnimal {
    public string Name {get; set;}
    public string Voice => "WUFF";
    public Dog(string name, int age = 0) {
        Name = name;
        Age = age;
    }
    public void Deconstruct(out string Name, out int Age) => (Name, Age) = (this.Name, this.Age);
    public void Deconstruct(out string Name, out int Age, out string Voice) {
        Name = this.Name;
        Age = this.Age;
        Voice = this.Voice;
    }
    public void move(int steps) {
        U.p($"I moved {steps} steps.");
    }
    public void talk(string message) {
        U.p($"Wooffing {message} loudly.");
    }
    public void introduceSelf() {
        U.p(ToString());
    }

    public override string ToString(){
        return $"Hi I'm {Name}, I'm a {this.GetType()}, I'm {Age}yo and this is my voice: {Voice}";
    }
}

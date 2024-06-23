using Utilities;

public class ComparerAnimal : Comparer<Animal>
{
    public override int Compare(Animal? animal1, Animal? animal2)
    {
        if(animal1 == null || animal2 == null) 
            throw new Exception("Animal cannot be null");
        return animal1.Age.CompareTo(animal2.Age) ;
    }
}

public class CompareAnimals {

  public static void exec(){
    U.pst("CompareAnimals");
    Animal lassie = new Dog("Lassie", 4); 
    Animal cassie = new Dog("Cassie", 5);
    Animal sassie = new Dog("Sassie", 2);
    List<Animal> dogs = [lassie, cassie, sassie];
    dogs.Sort(new ComparerAnimal());
    U.p(dogs);
  }
}
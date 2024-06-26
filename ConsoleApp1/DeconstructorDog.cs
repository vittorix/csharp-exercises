using Utilities;

public class DeconstructorDog
{

  public static void exec()
  {
    U.pst("DeconstructorDog");

    var cassie = new Dog("Cassie", 5);
    cassie.introduceSelf();
    var (name, age, voice) = cassie; // uses the deconstructor
    U.p($"name={name}, age={age}, voice={voice}");

    U.p();
    IAnimal lassie = new Dog("Lassie"); // Age is optional
    lassie.introduceSelf();
    lassie.move(5);
    lassie.talk("I'M HUNGRY");
    (name, age) = (Dog)lassie; // need to cast since lassie is an interface
    U.p($"name={name}, age={age}, voice={voice}");
  }
}
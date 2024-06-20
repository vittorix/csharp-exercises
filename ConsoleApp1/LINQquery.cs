using Utilities;

public class Element
{
    public required string Symbol { get; init; }
    public required string Name { get; init; }
    public required int AtomicNumber { get; init; }
}

public class LINQquery {
    public static void exec(){
        List<Element> elements = new() {
        { new(){ Symbol="K", Name="Potassium", AtomicNumber=19}},
        { new(){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
        { new(){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
        { new(){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
    };
    
    // System.Linq.IOrderedEnumerable<Element> subset = from theElement in elements
    var subset = from theElement in elements
                where theElement.AtomicNumber < 22
                orderby theElement.Name
                select theElement;

    foreach (Element theElement in subset)
        Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
    }
    //  Calcium 20
    //  Potassium 19
    //  Scandium 21
}

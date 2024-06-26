using Utilities;

public class ArraysLINQ
{
    public static void exec()
    {
        U.pst("ArraysLINQ");
        // Select is like map, Aggregate is like reduce:
        var array = new int[] { 1, 2, 3, 4 };
        U.pt(array);

        // multiplies the element * 10
        var multiplied = array.Select(x => x * 10);
        U.pt(multiplied);
        U.ps();

        // multiplies the element * 10 then multiplies then multipliex each * 2 and sums them
        // [10, 20, 30, 40] =>  20, 40, 60, 80 => 20 + 40 + 60 + 80 => 200
        var result = array.Select(x => x * 10).Aggregate(0, (prev, cur) => prev + cur * 2);
        U.p(result);
        U.ps();

        // if we specify the seed, initial condition, it uses as firt in aggregate (result = 213)
        result = array.Select(x => x * 10).Aggregate(13, (prev, cur) => prev + cur * 2);
        U.p(result);
        U.ps();

        // multiplication needs seed = 1
        int[] numbers = { 4, 7, 10 };
        U.p(numbers.Aggregate(1, (prev, next) => prev * next)); // 280
    }
}
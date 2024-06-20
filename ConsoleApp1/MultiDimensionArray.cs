using System.Runtime.CompilerServices;
using Utilities;

public class MultiDimensionArray {
    public static void exec(){
        int[,] arr2D = new int[4, 2]; // 4 rows x 2 columns = 8 elements
        U.p("4 x 2 arr2D has rank (dimension): " + arr2D.Rank + " length: " + arr2D.Length);

        int[,,] arr3D = new int[4, 2, 3]; // 4 x 2 x 3 = 24 elements
        U.p("4 x 2 X 3 arr3D has rank (dimension): " + arr3D.Rank + " length: " + arr3D.Length);
        U.p("---------");

        // 4 rows 2 columns
        int[,] array2D =  { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        U.p(array2D[0, 0]); // 1
        U.p(array2D[0, 1]); // 2
        U.p(array2D[1, 0]); // 3
        U.p(array2D[1, 1]); // 4
        U.p(array2D[3, 0]); // 7
        U.p(array2D[3, 1]); // 8
        U.p("array2D has rank (dimension): " + arr2D.Rank + " length: " + arr2D.Length);

        U.p("array2D:");
        foreach (int element in array2D){
            System.Console.Write($"{element}  ");
        }
        U.p("\n---------");

        U.p("array2D:");
        int numRows = array2D.GetLength(0);
        int numColumns = array2D.GetLength(1);
        U.p("rows: " + numRows + " cols: " + numColumns);
        for (int row = 0; row < numRows; row++) {
            for (int col = 0; col < numColumns; col++) {
                System.Console.Write($"[{row},{col}] " + array2D[row, col] + "     ");
            }
            System.Console.WriteLine();
        }
        U.p("---------");

        int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                                        { { 7, 8, 9 }, { 10, 11, 12 } } };
        int numXs = array3D.GetLength(0);
        int numYs = array3D.GetLength(1);
        int numZs = array3D.GetLength(2);

        U.p($"{numXs}x X {numYs}y X {numZs}z array3D has rank (dimension): " + arr3D.Rank + " length: " + arr3D.Length);                                        
        U.p(array3D[1, 0, 1]);
        U.p(array3D[1, 1, 2]);
        // Output:
        // 8
        // 12
        U.p("-----3D array----");


        for (int x = 0; x < numXs; x++) {
            for (int y = 0; y < numYs; y++) {
                for (int z = 0; z < numZs; z++) {
                    System.Console.Write($"[{x}, {y}, {z}] {array3D[x, y, z]}\t");
                }
                System.Console.WriteLine();
            }
                System.Console.WriteLine();
        }



        // Getting the total count of elements or the length of a given dimension.
        var total = 1;
        for (int i = 0; i < array3D.Rank; i++) {
            total *= array3D.GetLength(i);
        }
        U.p($"{array3D.Length} equals {total}");
        // Output:
        // 12 equals 12

        U.p("----- jagged arrays");
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = [1, 3, 5, 7, 9];
        jaggedArray[1] = [0, 2, 4, 6];
        jaggedArray[2] = [11, 22];

        int[][] jaggedArray2 = 
        [
            [1, 3, 5, 7, 9],
            [0, 2, 4, 6],
            [11, 22]
        ];

        // Assign 77 to the second element ([1]) of the first array ([0]):
        jaggedArray2[0][1] = 77;

        // Assign 88 to the second element ([1]) of the third array ([2]):
        jaggedArray2[2][1] = 88;

        int[][,] jaggedArray3 =
        [
            new int[,] { {1,3}, {5,7} },
            new int[,] { {0,2}, {4,6}, {8,10} },
            new int[,] { {11,22}, {99,88}, {0,9} }
        ];

        Console.WriteLine("jaggedArray3[0][1, 0]: " + jaggedArray3[0][1, 0]);
        Console.WriteLine("jaggedArray3.Rank: " + jaggedArray3.Rank);    
        Console.WriteLine("jaggedArray3.Length: " + jaggedArray3.Length);    
    }
}

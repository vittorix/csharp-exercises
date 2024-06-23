using System.Collections;

namespace Utilities
{
    public static class U {
        public static string newId () {
            return Guid.NewGuid().ToString();
        }

        public static void p (Object toPrint) {
            System.Console.WriteLine(toPrint);
        }

        public static void p () {
            System.Console.WriteLine();
        }

        public static void p (string toPrint) {
            Console.WriteLine(toPrint);
        }

        public static void p (IEnumerable toPrint, string separator = "\n", string title = "") {
            if(!string.IsNullOrEmpty(title)) 
                Console.Write(title);
            foreach(var element in toPrint) 
                Console.Write(element + separator);
            if(separator!="\n")
                Console.WriteLine();
        }

        public static void ps(string message = "") {
            if(string.IsNullOrWhiteSpace(message))
                p("--------");
            else 
                p($"-------- {message} --------");
        }
        public static void pst(string message = "") {
            if(string.IsNullOrWhiteSpace(message))
                p("=========");
            else 
                p($"========= {message} =========");
        }

        public static void pt (IEnumerable toPrint, string title = "") {
            p(toPrint, "\t", title);
        }

        // list.Reverse();
        public static string reverse(string s) {
            return new string(s.Reverse().ToArray());
            // string reversed = "";
            // for (int i= s.Length-1; i>=0; --i) {
            //     reversed += s[i];
            // }
            // return reversed;
        }

        // do
        // {
        //     var temp = array[firstIndex];
        //     array[firstIndex] = array[lastIndex];
        //     array[lastIndex] = temp;
        //     firstIndex++;
        //     lastIndex--;
        // } while (firstIndex < lastIndex);

        public static List<T> reverse<T>(List<T> list) {
            int n = list.Count;
            List<T> reversed= new List<T>(n);
            for (int i = n-1; i>=0; --i) {
                reversed.Add(list[i]);
            }
            return reversed;
        }
        public static int searchBinary<T>(T[] array, T target, int start, int end) where T : IComparable<T> {
            int center = (end + start) / 2;
            if (array[center].Equals(target)) {
                return center;
            }
            else if (array[center].CompareTo(target) > 0) {
                return searchBinary(array, target, center+1, end);
            }
            else if (array[center].CompareTo(target) < 0) {
                return searchBinary(array, target, start, center-1);
            }
            else 
                return -1;
        }
        public static int sum (IEnumerable<int> values) => values.Sum();
    }
}
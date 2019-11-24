using System;
using System.Linq;
using SampleArray.Util;

namespace SampleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = { "The", "Clean", "and", "Coder" };
            string[] array2 = { "Doodle", "Puzzle", "and", "Learn" };
            string[] array3 = { "Head", "First", "Head", "Hunter" };

            ArrayAction arrayAction = new ArrayAction();

            Result result = null;
            result = arrayAction.JoinAndSort(SortOrder.AtoZ, array1, array2);

            Console.WriteLine($"Unique Values, Sorted by {SortOrder.AtoZ}");
            foreach (var item in result.UniqueArray)
                Console.WriteLine(item);

            Console.WriteLine($"Duplicates(if any)");
            foreach (var item in result.DuplicateValues)
                Console.WriteLine(item);

            result = null;
            result = arrayAction.JoinAndSort(SortOrder.ZtoA, array1, array2, array3);

            Console.WriteLine();

            Console.WriteLine($"Unique Values, Sorted by {SortOrder.ZtoA}");
            foreach (var item in result.UniqueArray)
                Console.WriteLine(item);

            Console.WriteLine($"Duplicates(if any)");
            foreach (var item in result.DuplicateValues)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}

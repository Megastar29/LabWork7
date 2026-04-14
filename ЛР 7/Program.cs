using MyDoubleLinkedList;

namespace ЛР_7
{
    internal class Program
    {
        /// <summary>
        /// Serves as the entry point for the application.
        /// </summary>
        /// <remarks>This method demonstrates usage of the DoubleLinkedList class, including adding,
        /// removing, and iterating over elements, as well as invoking additional list operations.</remarks>
        /// <param name="args">An array of command-line arguments supplied to the application.</param>
        static void Main(string[] args)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.Add(4.0);
            list.Add(20.0);
            list.Add(10.5);
            list.Add(15.0);
            list.Add(30.0);
            list.Add(17.4);
            list.Add(15.5);

            Console.WriteLine("First list using foreach");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("\nFirst list using for and []");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();

            const int removeIndex = 3;
            list.Remove(removeIndex);

            Console.WriteLine($"\nList after removing element with index {removeIndex}");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("\nFinding the first element that less than avarage element");
            double lessAvg = list.FindFirstElLessThanAvgVal();
            Console.WriteLine(lessAvg);

            Console.WriteLine("\nFinding the sum of elements after the max element");
            Console.WriteLine(list.SumOfElAfterMaxEl());

            const double value = 11.0;
            Console.WriteLine($"\nNew list that has elements that are grater than {value}");
            var newList = list.GetElementsGraterThanValue(value);

            foreach (var item in newList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            list.DeleteAllElBeforeMax();

            Console.WriteLine($"\nAfter deleting elements before max element {list.FindMaxEl()}");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}

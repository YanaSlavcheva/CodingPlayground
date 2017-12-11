namespace DesignPatterns.Strategy
{
    using System.Collections.Generic;

    public class MergeSort : ISortingStrategy
    {
        public void Sort<T>(IEnumerable<T> dataToBeSorted)
        {
            // Merge sort logic here
            System.Console.WriteLine("Envoked MergeSort");
        }
    }
}

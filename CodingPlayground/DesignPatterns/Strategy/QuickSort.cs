namespace DesignPatterns.Strategy
{
    using System.Collections.Generic;

    public class QuickSort : ISortingStrategy
    {
        public void Sort<T>(IEnumerable<T> dataToBeSorted)
        {
            // Quick sort logic here
            System.Console.WriteLine("Envoked QuickSort");
        }
    }
}

namespace DesignPatterns.Strategy
{
    using System.Collections.Generic;

    public class HeapSort : ISortingStrategy
    {
        public void Sort<T>(IEnumerable<T> dataToBeSorted)
        {
            // Heap sort logic here
            System.Console.WriteLine("Envoked HeapSort");
        }
    }
}

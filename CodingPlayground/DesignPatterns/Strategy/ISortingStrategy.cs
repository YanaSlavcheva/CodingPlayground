namespace DesignPatterns.Strategy
{
    using System.Collections.Generic;

    public interface ISortingStrategy
    {
        void Sort<T>(IEnumerable<T> dataToBeSorted);
    }
}

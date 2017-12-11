namespace DesignPatterns
{
    using System.Collections.Generic;

    using DesignPatterns.Strategy;

    public class Program
    {
        static void Main(string[] args)
        {
            // STRATEGY
            var residents = new List<string> { "Gosho", "Pesho", "Ivan" };
            var residentsSortingStrategy = GetSortingStrategy(ObjectTypeEnum.Resident);
            residentsSortingStrategy.Sort<string>(residents);

            var ticketNumbers = new List<int> { 123, 234, 12 };
            var ticketNumbersSortingStrategy = GetSortingStrategy(ObjectTypeEnum.TicketNumber);
            ticketNumbersSortingStrategy.Sort<int>(ticketNumbers);

            var passengers = new List<string> { "Mimi", "Eli", "Vladko" };
            var passengersSortingStrategy = GetSortingStrategy(ObjectTypeEnum.Passenger);
            passengersSortingStrategy.Sort<string>(passengers);

            // SINGLETON
            // testing SingletonSimple
            var instanceOne = SingletonSimple.InstanceProperty;
            instanceOne.TestProperty = 5;
            System.Console.WriteLine(instanceOne.TestProperty);

            var instanceTwo = SingletonSimple.InstanceProperty;
            System.Console.WriteLine(instanceTwo.TestProperty);

            // testing SingletonStaticInitialization
            var instanceStaticOne = SingletonStaticInitialization.InstanceProperty;
            instanceStaticOne.TestProperty = 10;
            System.Console.WriteLine(instanceStaticOne.TestProperty);

            var instanceStaticTwo = SingletonStaticInitialization.InstanceProperty;
            System.Console.WriteLine(instanceStaticTwo.TestProperty);

            // testing SingletonThreadSafe
            var instanceThreadSafeOne = SingletonThreadSafe.InstanceProperty;
            instanceThreadSafeOne.TestProperty = 10;
            System.Console.WriteLine(instanceThreadSafeOne.TestProperty);

            var instanceThreadSafeTwo = SingletonThreadSafe.InstanceProperty;
            System.Console.WriteLine(instanceThreadSafeTwo.TestProperty);
        }

        private static ISortingStrategy GetSortingStrategy(ObjectTypeEnum objectsType)
        {
            ISortingStrategy sortingStrategy = null;

            switch (objectsType)
            {
                case ObjectTypeEnum.Resident:
                    sortingStrategy = new QuickSort();
                    break;
                case ObjectTypeEnum.TicketNumber:
                    sortingStrategy = new MergeSort();
                    break;
                case ObjectTypeEnum.Passenger:
                    sortingStrategy = new HeapSort();
                    break;
                default:
                    break;
            }

            System.Console.WriteLine($"Type of elements in collection: {objectsType} -> Chosen Strategy: {sortingStrategy}");
            return sortingStrategy;
        }
    }
}

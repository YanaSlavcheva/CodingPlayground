namespace DesignPatterns
{
    using System.Collections.Generic;

    using DesignPatterns.Strategy;
    using DesignPatterns.Template;
    using DesignPatterns.InversionOfControl;

    public class Program
    {
        static void Main(string[] args)
        {
            // Design patterns
            // SINGLETON Creational pattern
            TestSingleton();

            // STRATEGY Behavioral pattern
            TestStrategy();

            // TEMPLATE Behavioral pattern
            TestTemplate();

            // Inversion of Control
            TestInversionOfControl();
        }

        private static void TestSingleton()
        {
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

        private static void TestStrategy()
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
        }

        private static void TestTemplate()
        {
            // TEMPLATE
            var interviewForDeveloper = new InterviewProcessForDeveloper();
            interviewForDeveloper.InitiateInterviewProcess();

            var interviewForQa = new InterviewProcessForQa();
            interviewForQa.InitiateInterviewProcess();
        }

        private static void TestInversionOfControl()
        {
            IoC.Register<ILogger, Logger>();
            IoC.Register<ConsoleLogger, ConsoleLogger>();
            var objConsoleLogger = IoC.Resolve<ConsoleLogger>();
            objConsoleLogger.LogMessage();
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

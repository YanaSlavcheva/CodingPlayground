namespace DesignPatterns
{
    using System.Collections.Generic;

    using DesignPatterns.Strategy;
    using DesignPatterns.Template;
    using DesignPatterns.InversionOfControl;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            // Delegates
            TestDelegates();

            // Reflection
            TestReflection();

            // Inversion of Control
            TestInversionOfControl();

            // TEMPLATE Behavioral pattern
            TestTemplate();

            // STRATEGY Behavioral pattern
            TestStrategy();

            // Design patterns
            // SINGLETON Creational pattern
            TestSingleton();
        }


        public delegate void Del(string message);
        private static void TestDelegates()
        {
            Del handler = DelegateMethod;
            Console.WriteLine($"The type of handler is {handler.GetType()}");

            handler("Text to pass to DelegateMethod through the delegate Del");

            MethodForSumOfNumbersWithCallback(1, 2, handler);

            var collection = new List<int> { 1, 2, 3, 4, 5 };

            // function (Linq) as parameter for the function Where of the Assembly System => so it is Delegate
            var evenFromCollection = collection.Where(x => x % 2 == 0).Select(x => x).ToList();
            Console.WriteLine(string.Join(", ", evenFromCollection));
            Console.Read();
        }

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodForSumOfNumbersWithCallback(int parameterOne, int parameterTwo, Del callback)
        {
            callback($"The sum is {(parameterOne + parameterTwo).ToString()}");
        }

        private static void TestReflection()
        {
            var dateTimeWithReflection = (DateTime)Activator.CreateInstance(typeof(DateTime));
            Console.WriteLine($"Type of dateTimeWithReflection: {dateTimeWithReflection.GetType()}");

            var dateTimeTheCommonWay = new DateTime();
            Console.WriteLine($"Type of dateTimeTheCommonWay: {dateTimeTheCommonWay.GetType()}");
            Console.ReadLine();
        }

        private static void TestInversionOfControl()
        {
            IoC.Register<ILogger, Logger>();
            IoC.Register<ConsoleLogger, ConsoleLogger>();
            var objConsoleLogger = IoC.Resolve<ConsoleLogger>();
            objConsoleLogger.LogMessage();
        }

        private static void TestTemplate()
        {
            // TEMPLATE
            var interviewForDeveloper = new InterviewProcessForDeveloper();
            interviewForDeveloper.InitiateInterviewProcess();

            var interviewForQa = new InterviewProcessForQa();
            interviewForQa.InitiateInterviewProcess();
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
    }
}

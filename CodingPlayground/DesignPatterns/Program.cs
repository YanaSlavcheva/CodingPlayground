namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
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

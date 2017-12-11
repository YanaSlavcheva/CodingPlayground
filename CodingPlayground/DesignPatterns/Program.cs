namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            var instanceOne = SimpleSingleton.InstanceProperty;
            instanceOne.TestProperty = 5;
            System.Console.WriteLine(instanceOne.TestProperty);

            var instanceTwo = SimpleSingleton.InstanceProperty;
            System.Console.WriteLine(instanceTwo.TestProperty);
        }
    }
}

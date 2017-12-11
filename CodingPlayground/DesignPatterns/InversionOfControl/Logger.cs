namespace DesignPatterns.InversionOfControl
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                System.Console.WriteLine(message);
                System.Console.Read();
            }
        }
    }
}

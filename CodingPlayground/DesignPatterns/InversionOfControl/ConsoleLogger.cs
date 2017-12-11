namespace DesignPatterns.InversionOfControl
{
    public class ConsoleLogger
    {
        private ILogger logger = null;

        public ConsoleLogger(ILogger submittedLogger)
        {
            this.logger = submittedLogger;
            this.LogMessage();
        }

        public void LogMessage()
        {
            logger.Log("Message from Logger.cs -> LogMessage()");
        }
    }
}

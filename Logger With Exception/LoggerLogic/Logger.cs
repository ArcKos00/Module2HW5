namespace LoggerLogic
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger()
        {
        }

        public static Logger GetLogger
        {
            get
            {
                return _instance;
            }
        }

        public void Log(string message, InfoType type = InfoType.Info)
        {
            DateTime now = DateTime.Now;
            string logMessage = $"{now}: {type}: {message}";
            Console.WriteLine(logMessage);
            FileService.CreateFiles(now, logMessage);
        }
    }
}
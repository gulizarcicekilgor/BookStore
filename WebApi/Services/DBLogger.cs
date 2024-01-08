namespace WebApi.Services
{
    public class DBLooger: ILoggerService
    {
        public void Write(String message)
        {
            Console.WriteLine("[DBLooger] - " + message);
        }
    }
}
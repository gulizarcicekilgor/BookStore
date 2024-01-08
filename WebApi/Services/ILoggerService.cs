namespace WebApi.Services
{
    
    public interface ILoggerService
    {
        //nereye yazacağını bilmiyor. bunu implemente eden sınıflar bilmeli
        public void Write(string message);
    }


}
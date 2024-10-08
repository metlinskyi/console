public interface IResponse 
{
    Task ResponseAsync(HttpResponseMessage message, int number);
}
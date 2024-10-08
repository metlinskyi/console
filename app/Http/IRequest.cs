public interface IRequest 
{
    Task<HttpResponseMessage> RequestAsync(int number);
}
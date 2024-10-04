internal abstract class Request 
{
    public abstract Task<HttpResponseMessage> RequestAsync(int number);
}
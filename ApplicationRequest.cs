internal abstract class ApplicationRequest 
{
    public abstract Task<HttpResponseMessage> RequestAsync(int number);
}
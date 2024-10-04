internal abstract class Content 
{
    public abstract Task ResponseAsync(HttpResponseMessage response, int number);
}
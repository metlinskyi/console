internal class JsonContent : Content
{
    private readonly ApplicationArgs args;

    public JsonContent(ApplicationArgs args)
    {
        this.args = args;
    }

    public override async Task ResponseAsync(HttpResponseMessage response, int number)
    {
        await Task.Yield();
        response.Dispose();
    }
}
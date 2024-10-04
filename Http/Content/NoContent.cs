using Microsoft.Extensions.Logging;

internal class NoContent : Content
{
    private readonly ILogger<NoContent> logger;
    private readonly ApplicationArgs args;

    public NoContent(        
        ILogger<NoContent> logger, 
        ApplicationArgs args)
    {
        this.logger = logger;
        this.args = args;
    }

    public override async Task ResponseAsync(HttpResponseMessage response, int number)
    {
        await Task.Yield();
        response.Dispose();
    }
}
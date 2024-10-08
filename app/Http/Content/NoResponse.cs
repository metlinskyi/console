using Microsoft.Extensions.Logging;

internal class NoResponse : IResponse
{
    private readonly ILogger<NoResponse> logger;
    private readonly ApplicationArgs args;

    public NoResponse(        
        ILogger<NoResponse> logger, 
        ApplicationArgs args)
    {
        this.logger = logger;
        this.args = args;
    }

    public async Task ResponseAsync(HttpResponseMessage response, int number)
    {
        await Task.Yield();
        response.Dispose();
    }
}
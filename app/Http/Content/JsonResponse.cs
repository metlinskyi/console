using Microsoft.Extensions.Logging;

internal class JsonResponse : IResponse
{
    private readonly ILogger<JsonResponse> logger;
    private readonly ApplicationArgs args;

    public JsonResponse(        
        ILogger<JsonResponse> logger,
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
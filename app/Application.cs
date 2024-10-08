using System.Diagnostics;
using Microsoft.Extensions.Logging;

internal sealed class Application 
{
    private readonly ILogger logger;
    private readonly ApplicationArgs args;
    private readonly IRequest request;
    private readonly IResponse response;

    public Application(
        ILogger<Application> logger, 
        ApplicationArgs args,
        IRequest request,
        IResponse response)
    {
        this.logger = logger;
        this.args = args;
        this.request = request;
        this.response = response;
    }

    public async Task Run()
    {        
        HttpResponseMessage? message = null;

        logger.LogInformation($"{args.BaseAddress}{args.RequestUri}");

        var watch = Stopwatch.StartNew();

        try
        {        
            foreach(int n in Enumerable.Range(args.Start, args.Count))
            {
                message = await request.RequestAsync(n);
                message.EnsureSuccessStatusCode();
                await response.ResponseAsync(message, n);
            }
        }
        catch (HttpRequestException e)
        {
            logger.LogError(e, string.Empty);
        }
        finally
        {
            watch.Stop();

            logger.LogInformation(watch.Elapsed.Minutes > 0 
                ? $"{watch.Elapsed.Minutes} minutes"
                : $"{watch.Elapsed.Seconds} seconds");
        }
    }
}
using System.Diagnostics;
using Microsoft.Extensions.Logging;

internal sealed class Application 
{
    private readonly ILogger logger;
    private readonly ApplicationArgs args;
    private readonly Request request;
    private readonly Content content;

    public Application(
        ILogger<Application> logger, 
        ApplicationArgs args,
        Request request,
        Content content)
    {
        this.logger = logger;
        this.args = args;
        this.request = request;
        this.content = content;
    }

    public async Task Run()
    {        
        HttpResponseMessage? response = null;

        logger.LogInformation($"{args.BaseAddress}{args.RequestUri}");

        var watch = Stopwatch.StartNew();

        try
        {        
            foreach(int n in Enumerable.Range(args.Start, args.Count))
            {
                response = await request.RequestAsync(n);
                response.EnsureSuccessStatusCode();
                await content.ResponseAsync(response, n);
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
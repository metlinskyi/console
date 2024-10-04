using System.Diagnostics;
using Microsoft.Extensions.Logging;

internal sealed class Application 
{
    private readonly ILogger logger;
    private readonly ApplicationArgs args;
    private readonly ApplicationRequest request;

    public Application(
        ILogger<Application> logger, 
        ApplicationArgs args,
        ApplicationRequest request)
    {
        this.logger = logger;
        this.args = args;
        this.request = request;
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
                if(n < args.Count)
                    response.Dispose();
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
                
            if(response != null)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                response?.Dispose();
                logger.LogInformation(responseBody);
            }
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class ApplicationRequestFactory 
{
    private readonly ILogger<ApplicationRequestFactory> logger;
    private readonly ApplicationArgs args;

    public ApplicationRequestFactory(
        ILogger<ApplicationRequestFactory> logger, 
        ApplicationArgs args
        )
    {
        this.logger = logger;
        this.args = args;
    }

    public ApplicationRequest CreateRequest(IServiceProvider provider)
    {
        logger.LogInformation($"{args.Method} method");
        
        switch(args.Method){
            case "GET":
                return provider.GetKeyedService<ApplicationRequest>(HttpMethod.Get) 
                    ?? throw new KeyNotFoundException("GET");
            case "POST":
                return provider.GetKeyedService<ApplicationRequest>(HttpMethod.Post) 
                    ?? throw new KeyNotFoundException("POST");
        }

        throw new NotSupportedException(args.Method);
    }
}
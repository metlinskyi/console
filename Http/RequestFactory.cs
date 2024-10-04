using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class RequestFactory 
{
    private readonly ILogger<RequestFactory> logger;
    private readonly ApplicationArgs args;

    public RequestFactory(
        ILogger<RequestFactory> logger, 
        ApplicationArgs args
        )
    {
        this.logger = logger;
        this.args = args;
    }

    public Request CreateRequest(IServiceProvider provider)
    {
        logger.LogInformation($"{args.Method} method");
        
        switch(args.Method){
            case "GET":
                return provider.GetKeyedService<Request>(HttpMethod.Get) 
                    ?? throw new KeyNotFoundException("GET");
            case "POST":
                return provider.GetKeyedService<Request>(HttpMethod.Post) 
                    ?? throw new KeyNotFoundException("POST");
        }

        throw new NotSupportedException(args.Method);
    }
}
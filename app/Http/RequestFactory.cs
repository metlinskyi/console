using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class RequestFactory : IFactory<IRequest>
{
    private readonly ILogger<RequestFactory> logger;
    private readonly IServiceProvider provider;
    private readonly ApplicationArgs args;

    public RequestFactory(
        ILogger<RequestFactory> logger, 
        IServiceProvider provider,
        ApplicationArgs args
        )
    {
        this.logger = logger;
        this.provider = provider;
        this.args = args;
    }

    public IRequest Create()
    {
        logger.LogInformation($"{args.Method} method");

        return provider.GetKeyedService<IRequest>(args.Method) 
            ?? throw new KeyNotFoundException(args.Method.ToString());
    }
}
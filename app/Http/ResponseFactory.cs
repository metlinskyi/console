using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class ResponseFactory : IFactory<IResponse>
{
    private readonly ILogger<ResponseFactory> logger;
    private readonly IServiceProvider provider;
    private readonly ApplicationArgs args;

    public ResponseFactory(
        ILogger<ResponseFactory> logger,
        IServiceProvider provider, 
        ApplicationArgs args
        )
    {
        this.logger = logger;
        this.provider = provider;
        this.args = args;
    }

    public IResponse Create()
    {
        logger.LogInformation($"{args.ContentType} content type");

        return provider.GetKeyedService<IResponse>(args.ContentType) 
            ?? throw new KeyNotFoundException(args.ContentType.ToString());
    }
}
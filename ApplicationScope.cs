using Microsoft.Extensions.DependencyInjection;

internal static class ApplicationScope 
{ 
    public static async Task CreateApplicationScope(this IServiceProvider hostProvider)
    {
        using IServiceScope serviceScope = hostProvider.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        var application = provider.GetRequiredService<Application>();
        await application.Run();
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
       return  
            services
                .AddTransient<Client>()
                .AddTransient<Cookie>()
                .AddTransient<RequestFactory>()
                .AddTransient<Request>((provider) => provider.GetRequiredService<RequestFactory>().CreateRequest(provider))
                .AddTransient<Content, NoContent>()
                .AddKeyedTransient<Request, GetRequest>(HttpMethod.Get)
                .AddKeyedTransient<Request, PostRequest>(HttpMethod.Post);
    }
}
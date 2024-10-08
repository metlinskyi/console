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

    public static T Factory<T>(this IServiceProvider provider)
    {
        return provider.GetRequiredService<IFactory<T>>().Create();
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
       return  
            services
                .AddTransient<Client>()
                .AddTransient<Cookie>()
                .AddTransient<IFactory<IRequest>, RequestFactory>()
                .AddTransient<IRequest>((provider) => provider.Factory<IRequest>())
                .AddKeyedTransient<IRequest, GetRequest>(HttpMethod.Get)
                .AddKeyedTransient<IRequest, PostRequest>(HttpMethod.Post)
                .AddTransient<IFactory<IResponse>, ResponseFactory>()
                .AddTransient<IResponse>((provider) => provider.Factory<IResponse>())
                .AddKeyedTransient<IResponse, NoResponse>(ContentType.No)
                .AddKeyedTransient<IResponse, JsonResponse>(ContentType.Json);
    }
}
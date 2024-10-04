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
}
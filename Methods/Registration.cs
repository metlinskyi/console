using Microsoft.Extensions.DependencyInjection;

internal static class Registration
{
    public static IServiceCollection AddMethods(this IServiceCollection services)
    {
       return  
            services
                .AddKeyedTransient<ApplicationRequest, GetRequest>(HttpMethod.Get)
                .AddKeyedTransient<ApplicationRequest, PostRequest>(HttpMethod.Post);
    }
}
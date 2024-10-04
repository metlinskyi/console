using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await new ServiceCollection()
    .AddLogging(config => config.AddConsole())
    .AddScoped<ApplicationArgs>((provider) => new ApplicationArgs(args))
    .AddScoped<ApplicationClient>()
    .AddScoped<ApplicationRequestFactory>()
    .AddScoped<ApplicationRequest>((provider) => provider.GetRequiredService<ApplicationRequestFactory>().CreateRequest(provider))
    .AddScoped<ApplicationCookie>()
    .AddScoped<Application>()
    .AddMethods()
    .BuildServiceProvider()
    .CreateApplicationScope();   

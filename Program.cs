using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await new ServiceCollection()
    .AddLogging(config => config.AddConsole())
    .AddScoped<ApplicationArgs>((provider) => new ApplicationArgs(args))
    .AddScoped<ApplicationClient>()
    .AddScoped<ApplicationCookie>()
    .AddScoped<Application>()
    .BuildServiceProvider()
    .CreateApplicationScope();   

using System.Net;
using System.Runtime.Serialization.Formatters.Soap;
using Microsoft.Extensions.Logging;

internal class ApplicationCookie : IDisposable
{
    private readonly SoapFormatter formatter = new SoapFormatter();
    private readonly CookieContainer container = new CookieContainer();
    private readonly ILogger<ApplicationCookie> logger;
    private readonly FileInfo? file = null;

    public ApplicationCookie(
        ILogger<ApplicationCookie> logger, 
        ApplicationArgs args)
    {
        this.logger = logger;

        if(!string.IsNullOrEmpty(args.Cookies))
        {
            file = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{args.Cookies}.dat")); 
            if(file.Exists)
            {
        
                using (Stream s = file.OpenRead())
                    container = (CookieContainer) formatter.Deserialize(s);

                logger.LogInformation($"Deserialize cookie from {file.FullName}");
            }
        }
    }

    public void Dispose()
    {
        if(file != null)
        {
            using (Stream s = file.Create())
                formatter.Serialize(s, container);       

            logger.LogInformation($"Serialize cookie to {file.FullName}");
        }
    }

    public static implicit operator CookieContainer(ApplicationCookie c) => c.container;
}
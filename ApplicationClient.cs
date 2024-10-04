internal class ApplicationClient : HttpClient
{
    public ApplicationClient(
        ApplicationArgs args, 
        ApplicationCookie cookie) 
        : base(new HttpClientHandler { 
                            AllowAutoRedirect = true, 
                            UseCookies = true, 
                            CookieContainer = cookie})
    {
        BaseAddress = args.BaseAddress != null ? new Uri(args.BaseAddress) : null;
    }
}
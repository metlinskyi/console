internal class Client : HttpClient
{
    public Client(
        ApplicationArgs args, 
        Cookie cookie) 
        : base(new HttpClientHandler { 
                            AllowAutoRedirect = true, 
                            UseCookies = true, 
                            CookieContainer = cookie})
    {
        BaseAddress = args.BaseAddress != null ? new Uri(args.BaseAddress) : null;
    }
}
internal class GetRequest : ApplicationRequest
{
    private readonly ApplicationClient client;
    private readonly ApplicationArgs args;

    public GetRequest(
        ApplicationClient client,
        ApplicationArgs args)
    {
        this.client = client;
        this.args = args;
    }

    public override Task<HttpResponseMessage> RequestAsync(int number)
    {
        return client.GetAsync(string.Format(args.RequestUri, number));
    }
}
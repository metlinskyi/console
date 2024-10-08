internal class GetRequest : IRequest
{
    private readonly ApplicationArgs args;
    private readonly Client client;

    public GetRequest(
        ApplicationArgs args,
        Client client)
    {
        this.args = args;
        this.client = client;
    }

    public Task<HttpResponseMessage> RequestAsync(int number)
    {
        return client.GetAsync(string.Format(args.RequestUri, number));
    }
}
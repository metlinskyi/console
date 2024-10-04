internal class PostRequest : Request
{
    private readonly ApplicationArgs args;
    private readonly Client client;

    public PostRequest(
        ApplicationArgs args,
        Client client)
    {
        this.args = args;
        this.client = client;
    }

    public override Task<HttpResponseMessage> RequestAsync(int number)
    {
        return client.PostAsync(string.Format(args.RequestUri, number), null);
    }
}
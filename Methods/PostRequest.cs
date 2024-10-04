
internal class PostRequest : ApplicationRequest
{
    private readonly ApplicationClient client;
    private readonly ApplicationArgs args;

    public PostRequest(
        ApplicationClient client,
        ApplicationArgs args)
    {
        this.client = client;
        this.args = args;
    }

    public override Task<HttpResponseMessage> RequestAsync(int number)
    {
        return client.PostAsync(string.Format(args.RequestUri, number), null);
    }
}
using System.CommandLine;

internal record ApplicationArgs 
{
    public ApplicationArgs(string[] args)
    {
        var cookiesOption = new Option<string?>(
            aliases: ["-cookies", "--Cookies"],
            getDefaultValue: () => null);

        var baseOption = new Option<string>(
            aliases: ["-b", "--BaseAddress"],
            getDefaultValue: () => "http://localhost");

        var requestUriOption = new Option<string>(
            aliases: ["-r", "--RequestUri"],
            getDefaultValue: () => "/{0}");

        var methodOption = new Option<string>(
            aliases: ["-m", "--Method"],
            description: "GET,POST supported only",
            getDefaultValue: () => "GET");

        var startOption = new Option<int>(
            aliases: ["-s", "--Start"],
            getDefaultValue: () => 0);

        var countOption = new Option<int>(
            aliases: ["-c", "--Count"],
            getDefaultValue: () => 10);

        var rootCommand = new RootCommand
        {
            cookiesOption,
            baseOption,
            requestUriOption,
            methodOption,
            startOption,
            countOption
        };

        rootCommand.SetHandler((cookies, baseAddress, requestUri, method, start, count) =>
        {
            Cookies = cookies;
            BaseAddress = baseAddress;
            RequestUri = requestUri;
            Method = GetHttpMethod(method);
            Start = start;
            Count = count;
        }, cookiesOption, baseOption, requestUriOption, methodOption, startOption, countOption);

        rootCommand.Invoke(args);
    }

    public string? Cookies { get; private set; } = string.Empty;
    public string BaseAddress { get; private set; } = string.Empty;
    public string RequestUri { get; private set; } = string.Empty;
    public int Start { get; private set; }
    public int Count { get; private set; }
    public HttpMethod Method { get; private set; } = HttpMethod.Get;
    public ContentType ContentType { get; private set; }

    private HttpMethod GetHttpMethod(string method)
    {
        switch(method.ToUpper()){
            case "GET":
                return HttpMethod.Get;
            case "POST":
                return HttpMethod.Post;
        }

        throw new NotSupportedException($"The method '{method}' is not supported.");
    }
}

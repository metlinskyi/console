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
            startOption,
            countOption
        };

        rootCommand.SetHandler((cookies, baseAddress, requestUri, start, count) =>
        {
            Cookies = cookies;
            BaseAddress = baseAddress;
            RequestUri = requestUri;
            Start = start;
            Count = count;
        }, cookiesOption, baseOption, requestUriOption, startOption, countOption);

        rootCommand.Invoke(args);
    }

    public string? Cookies { get; private set; } = string.Empty;
    public string BaseAddress { get; private set; } = string.Empty;
    public string RequestUri { get; private set; } = string.Empty;
    public int Start { get; private set; }
    public int Count { get; private set; }
}

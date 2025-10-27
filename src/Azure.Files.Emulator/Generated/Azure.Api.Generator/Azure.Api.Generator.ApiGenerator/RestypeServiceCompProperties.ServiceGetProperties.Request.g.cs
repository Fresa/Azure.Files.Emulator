#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties;
internal partial class Request
{
    internal required HttpContext HttpContext { get; init; }
    internal required Azure.Files.Emulator.RestypeServiceCompProperties.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.RestypeServiceCompProperties.CompQuery Comp { get; init; }
    internal Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.XMsVersionHeader XMsVersion { get; init; }
    internal Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Task<Request> BindAsync(HttpContext context, CancellationToken cancellationToken)
    {
        var httpRequest = context.Request;
        var request = new Request
        {
            HttpContext = context,
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.RestypeServiceCompProperties.RestypeQuery>(httpRequest, """
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "service"
  ]
}
"""),
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.RestypeServiceCompProperties.CompQuery>(httpRequest, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "properties"
  ]
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.TimeoutQuery>(httpRequest, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.XMsVersionHeader>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-version",
  "description": "Specifies the version of the operation to use for this request.",
  "required": true,
  "type": "string",
  "enum": [
    "2025-11-05"
  ],
  "x-ms-client-name": "version",
  "x-ms-parameter-location": "client"
}
"""),
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.XMsFileRequestIntentHeader>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-file-request-intent",
  "description": "Valid value is backup",
  "type": "string",
  "enum": [
    "backup"
  ],
  "x-ms-client-name": "fileRequestIntent",
  "x-ms-enum": {
    "name": "ShareTokenIntent",
    "modelAsString": true
  }
}
""").AsOptional(),
        };
        return Task.FromResult(request);
    }
}
#nullable restore


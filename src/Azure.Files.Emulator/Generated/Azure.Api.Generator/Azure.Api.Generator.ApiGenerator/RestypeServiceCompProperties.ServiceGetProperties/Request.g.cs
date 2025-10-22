#nullable enable
using Corvus.Json;

namespace RestypeServiceCompProperties.ServiceGetProperties;
internal partial class Request
{
    internal required RestypeServiceCompProperties.RestypeQuery Restype { get; init; }
    internal required RestypeServiceCompProperties.CompQuery Comp { get; init; }
    internal RestypeServiceCompProperties.ServiceGetProperties.TimeoutQuery? Timeout { get; init; }
    internal required RestypeServiceCompProperties.ServiceGetProperties.XMsVersionHeader XMsVersion { get; init; }
    internal RestypeServiceCompProperties.ServiceGetProperties.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.RestypeQuery>(request, """
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
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.CompQuery>(request, """
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
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceGetProperties.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceGetProperties.XMsVersionHeader>(request, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceGetProperties.XMsFileRequestIntentHeader>(request, """
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
    }
}
#nullable restore


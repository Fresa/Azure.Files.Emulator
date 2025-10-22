#nullable enable
using Corvus.Json;

namespace RestypeServiceCompProperties.ServiceSetProperties;
internal partial class Request
{
    internal required RestypeServiceCompProperties.RestypeQuery Restype { get; init; }
    internal required RestypeServiceCompProperties.CompQuery Comp { get; init; }
    internal RestypeServiceCompProperties.ServiceSetProperties.TimeoutQuery? Timeout { get; init; }
    internal required RestypeServiceCompProperties.ServiceSetProperties.XMsVersionHeader XMsVersion { get; init; }
    internal RestypeServiceCompProperties.ServiceSetProperties.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal required RequestContent Body { get; init; }

    internal sealed class RequestContent
    {
        internal RestypeServiceCompProperties.ServiceSetProperties.RequestBodies.ApplicationXml? ApplicationXml { get; private set; }

        internal static RequestContent Bind(HttpRequest request)
        {
            var requestContentType = request.ContentType;
            var requestContentMediaType = requestContentType == null ? null : System.Net.Http.Headers.MediaTypeHeaderValue.Parse(requestContentType);
            switch (requestContentMediaType?.MediaType?.ToLower())
            {
                case "application/xml":
                    return new RequestContent
                    {
                        ApplicationXml = OpenApiGenerator.HttpRequestExtensions.BindBody<RestypeServiceCompProperties.ServiceSetProperties.RequestBodies.ApplicationXml>(request).AsOptional()
                    };
                default:
                    throw new BadHttpRequestException($"Request body does not support content type {requestContentType}");
            }
        }
    }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            Restype = OpenApiGenerator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.RestypeQuery>(request, """
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
            Comp = OpenApiGenerator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.CompQuery>(request, """
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
            Timeout = OpenApiGenerator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceSetProperties.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = OpenApiGenerator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceSetProperties.XMsVersionHeader>(request, """
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
            XMsFileRequestIntent = OpenApiGenerator.HttpRequestExtensions.Bind<RestypeServiceCompProperties.ServiceSetProperties.XMsFileRequestIntentHeader>(request, """
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
            Body = RequestContent.Bind(request)
        };
    }
}
#nullable restore


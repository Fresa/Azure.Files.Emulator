#nullable enable
using OpenApiGenerator;
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
                        ApplicationXml = request.BindBody<RestypeServiceCompProperties.ServiceSetProperties.RequestBodies.ApplicationXml>().AsOptional()
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
            Restype = request.Bind<RestypeServiceCompProperties.RestypeQuery>("""
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
            Comp = request.Bind<RestypeServiceCompProperties.CompQuery>("""
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
            Timeout = request.Bind<RestypeServiceCompProperties.ServiceSetProperties.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<RestypeServiceCompProperties.ServiceSetProperties.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<RestypeServiceCompProperties.ServiceSetProperties.XMsFileRequestIntentHeader>("""
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


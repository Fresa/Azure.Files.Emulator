#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompAcl.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompAcl.CompQuery Comp { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal RequestContent? Body { get; init; }

    internal sealed class RequestContent
    {
        internal Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.RequestBodies.ApplicationXml? ApplicationXml { get; private set; }

        internal static RequestContent? Bind(HttpRequest request)
        {
            var requestContentType = request.ContentType;
            var requestContentMediaType = requestContentType == null ? null : System.Net.Http.Headers.MediaTypeHeaderValue.Parse(requestContentType);
            switch (requestContentMediaType?.MediaType?.ToLower())
            {
                case "application/xml":
                    return new RequestContent
                    {
                        ApplicationXml = Azure.Files.Emulator.HttpRequestExtensions.BindBody<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.RequestBodies.ApplicationXml>(request).AsOptional()
                    };
                case "":
                    return null;
                default:
                    throw new BadHttpRequestException($"Request body does not support content type {requestContentType}");
            }
        }
    }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            ShareName = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.RestypeQuery>(request, """
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "share"
  ]
}
"""),
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "acl"
  ]
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsVersionHeader>(request, """
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
            XMsLeaseId = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-lease-id",
  "description": "If specified, the operation only succeeds if the resource's lease is active and matches this ID.",
  "type": "string",
  "x-ms-client-name": "leaseId",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "lease-access-conditions"
  }
}
""").AsOptional(),
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsFileRequestIntentHeader>(request, """
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


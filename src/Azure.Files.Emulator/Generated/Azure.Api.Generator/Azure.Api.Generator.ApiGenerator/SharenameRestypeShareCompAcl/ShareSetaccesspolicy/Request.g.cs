#nullable enable
using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompAcl.ShareSetAccessPolicy;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required ShareNameRestypeShareCompAcl.RestypeQuery Restype { get; init; }
    internal required ShareNameRestypeShareCompAcl.CompQuery Comp { get; init; }
    internal ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal RequestContent? Body { get; init; }

    internal sealed class RequestContent
    {
        internal ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.RequestBodies.ApplicationXml? ApplicationXml { get; private set; }

        internal static RequestContent? Bind(HttpRequest request)
        {
            var requestContentType = request.ContentType;
            switch (requestContentType)
            {
                case "application/xml":
                    return new RequestContent
                    {
                        ApplicationXml = request.BindBody<ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.RequestBodies.ApplicationXml>().AsOptional()
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
            ShareName = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Restype = request.Bind<ShareNameRestypeShareCompAcl.RestypeQuery>("""
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
            Comp = request.Bind<ShareNameRestypeShareCompAcl.CompQuery>("""
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
            Timeout = request.Bind<ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsVersionHeader>("""
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
            XMsLeaseId = request.Bind<Corvus.Json.JsonString>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.XMsFileRequestIntentHeader>("""
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


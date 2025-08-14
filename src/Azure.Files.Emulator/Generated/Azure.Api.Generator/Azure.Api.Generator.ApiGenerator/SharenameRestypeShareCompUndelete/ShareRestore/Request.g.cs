using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompUndelete.ShareRestore;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required ShareNameRestypeShareCompUndelete.RestypeQuery Restype { get; init; }
    internal required ShareNameRestypeShareCompUndelete.CompQuery Comp { get; init; }
    internal ShareNameRestypeShareCompUndelete.ShareRestore.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameRestypeShareCompUndelete.ShareRestore.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal Corvus.Json.JsonString? XMsDeletedShareName { get; init; }
    internal Corvus.Json.JsonString? XMsDeletedShareVersion { get; init; }
    internal ShareNameRestypeShareCompUndelete.ShareRestore.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Restype = request.Bind<ShareNameRestypeShareCompUndelete.RestypeQuery>("""
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
            Comp = request.Bind<ShareNameRestypeShareCompUndelete.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "undelete"
  ]
}
"""),
            Timeout = request.Bind<ShareNameRestypeShareCompUndelete.ShareRestore.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameRestypeShareCompUndelete.ShareRestore.XMsVersionHeader>("""
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
            XMsClientRequestId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-client-request-id",
  "description": "Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.",
  "type": "string",
  "x-ms-client-name": "requestId",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsDeletedShareName = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-deleted-share-name",
  "description": "Specifies the name of the previously-deleted share.",
  "type": "string",
  "x-ms-client-name": "DeletedShareName",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsDeletedShareVersion = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-deleted-share-version",
  "description": "Specifies the version of the previously-deleted share.",
  "type": "string",
  "x-ms-client-name": "DeletedShareVersion",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<ShareNameRestypeShareCompUndelete.ShareRestore.XMsFileRequestIntentHeader>("""
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

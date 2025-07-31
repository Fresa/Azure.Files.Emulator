using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString Filename { get; init; }
    internal required SharenameDirectoryFilenameRestypeSymboliclink.RestypeQuery Restype { get; init; }
    internal SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal required SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            Sharename = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Directory = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "path",
  "name": "directory",
  "description": "The path of the target directory.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method",
  "x-ms-skip-url-encoding": false
}
"""),
            Filename = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "path",
  "name": "fileName",
  "description": "The path of the target file.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method",
  "x-ms-skip-url-encoding": false
}
"""),
            Restype = request.Bind<SharenameDirectoryFilenameRestypeSymboliclink.RestypeQuery>("""
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "symboliclink"
  ]
}
"""),
            Timeout = request.Bind<SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Sharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink.XMsFileRequestIntentHeader>("""
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

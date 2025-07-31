using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required SharenameDirectoryCompForceclosehandles.CompQuery Comp { get; init; }
    internal SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonString? Marker { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal required Corvus.Json.JsonString XMsHandleId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsRecursive { get; init; }
    internal required SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = request.Bind<SharenameDirectoryCompForceclosehandles.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "forceclosehandles"
  ]
}
"""),
            Timeout = request.Bind<SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Marker = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "marker",
  "description": "A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.",
  "type": "string",
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
            XMsHandleId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-handle-id",
  "description": "Specifies handle ID opened on the file or directory to be closed. Asterisk (‘*’) is a wildcard that specifies all handles.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "handleId",
  "x-ms-parameter-location": "method"
}
"""),
            XMsRecursive = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-recursive",
  "description": "Specifies operation should apply to the directory specified in the URI, its files, its subdirectories and their files.",
  "type": "boolean",
  "x-ms-client-name": "recursive",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.XMsVersionHeader>("""
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
            XMsAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles.XMsFileRequestIntentHeader>("""
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

#nullable enable
using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryCompListhandles.DirectoryListHandles;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required ShareNameDirectoryCompListhandles.CompQuery Comp { get; init; }
    internal Corvus.Json.JsonString? Marker { get; init; }
    internal ShareNameDirectoryCompListhandles.DirectoryListHandles.MaxresultsQuery? Maxresults { get; init; }
    internal ShareNameDirectoryCompListhandles.DirectoryListHandles.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal Corvus.Json.JsonBoolean? XMsRecursive { get; init; }
    internal required ShareNameDirectoryCompListhandles.DirectoryListHandles.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal ShareNameDirectoryCompListhandles.DirectoryListHandles.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = request.Bind<ShareNameDirectoryCompListhandles.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "listhandles"
  ]
}
"""),
            Marker = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "marker",
  "description": "A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Maxresults = request.Bind<ShareNameDirectoryCompListhandles.DirectoryListHandles.MaxresultsQuery>("""
{
  "in": "query",
  "name": "maxresults",
  "description": "Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.",
  "type": "integer",
  "minimum": 1,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = request.Bind<ShareNameDirectoryCompListhandles.DirectoryListHandles.TimeoutQuery>("""
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
            XMsVersion = request.Bind<ShareNameDirectoryCompListhandles.DirectoryListHandles.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryCompListhandles.DirectoryListHandles.XMsFileRequestIntentHeader>("""
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


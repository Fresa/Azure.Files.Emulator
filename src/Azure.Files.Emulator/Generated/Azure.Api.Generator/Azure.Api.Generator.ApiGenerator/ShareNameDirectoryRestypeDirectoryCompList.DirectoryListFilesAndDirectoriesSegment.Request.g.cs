#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment;
internal partial class Request
{
    internal required HttpContext HttpContext { get; init; }
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.CompQuery Comp { get; init; }
    internal Corvus.Json.JsonString? Prefix { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal Corvus.Json.JsonString? Marker { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.MaxresultsQuery? Maxresults { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.XMsVersionHeader XMsVersion { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.IncludeQuery? Include { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileExtendedInfo { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpContext context)
    {
        var request = context.Request;
        return new Request
        {
            HttpContext = context,
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
            Directory = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.RestypeQuery>(request, """
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "directory"
  ]
}
"""),
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "list"
  ]
}
"""),
            Prefix = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "query",
  "name": "prefix",
  "description": "Filters the results to return only entries whose name begins with the specified prefix.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Sharesnapshot = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Marker = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "query",
  "name": "marker",
  "description": "A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Maxresults = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.MaxresultsQuery>(request, """
{
  "in": "query",
  "name": "maxresults",
  "description": "Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.",
  "type": "integer",
  "minimum": 1,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.XMsVersionHeader>(request, """
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
            Include = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.IncludeQuery>(request, """
{
  "in": "query",
  "name": "include",
  "description": "Include this parameter to specify one or more datasets to include in the response.",
  "type": "array",
  "items": {
    "type": "string",
    "enum": [
      "Timestamps",
      "Etag",
      "Attributes",
      "PermissionKey"
    ],
    "x-ms-enum": {
      "name": "ListFilesIncludeType",
      "modelAsString": false
    }
  },
  "collectionFormat": "multi",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileExtendedInfo = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-file-extended-info",
  "description": "Include extended information.",
  "type": "boolean",
  "x-ms-client-name": "includeExtendedInfo",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsAllowTrailingDot = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.XMsFileRequestIntentHeader>(request, """
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


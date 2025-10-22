#nullable enable
using OpenApiGenerator;
using Corvus.Json;

namespace ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required ShareNameDirectoryFileNameRestypeSymboliclink.RestypeQuery Restype { get; init; }
    internal ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal required ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal Corvus.Json.JsonString? XMsFileCreationTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonString? XMsOwner { get; init; }
    internal Corvus.Json.JsonString? XMsGroup { get; init; }
    internal required Corvus.Json.JsonString XMsLinkText { get; init; }

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
            FileName = request.Bind<Corvus.Json.JsonString>("""
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
            Restype = request.Bind<ShareNameDirectoryFileNameRestypeSymboliclink.RestypeQuery>("""
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
            Timeout = request.Bind<ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.TimeoutQuery>("""
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
            XMsVersion = request.Bind<ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.XMsFileRequestIntentHeader>("""
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
            XMsMeta = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-meta",
  "description": "A name-value pair to associate with a file storage object.",
  "type": "string",
  "x-ms-client-name": "metadata",
  "x-ms-parameter-location": "method",
  "x-ms-header-collection-prefix": "x-ms-meta-"
}
""").AsOptional(),
            XMsFileCreationTime = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-creation-time",
  "description": "Creation time for the file/directory. Default value: Now.",
  "type": "string",
  "format": "date-time-rfc1123",
  "x-ms-client-name": "FileCreationTime",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileLastWriteTime = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-last-write-time",
  "description": "Last write time for the file/directory. Default value: Now.",
  "type": "string",
  "format": "date-time-rfc1123",
  "x-ms-client-name": "FileLastWriteTime",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
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
            XMsOwner = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-owner",
  "description": "Optional, NFS only. The owner of the file or directory.",
  "type": "string",
  "x-ms-client-name": "owner",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsGroup = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-group",
  "description": "Optional, NFS only. The owning group of the file or directory.",
  "type": "string",
  "x-ms-client-name": "group",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLinkText = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-link-text",
  "description": "NFS only. Required. The path to the original file, the symbolic link is pointing to. The path is of type string which is not resolved and is stored as is. The path can be absolute path or the relative path depending on the content stored in the symbolic link file.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "linkText",
  "x-ms-parameter-location": "method"
}
"""),
        };
    }
}
#nullable restore


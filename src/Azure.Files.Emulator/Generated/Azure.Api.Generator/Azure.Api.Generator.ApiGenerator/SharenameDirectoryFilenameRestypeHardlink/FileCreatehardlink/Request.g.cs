#nullable enable
using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required ShareNameDirectoryFileNameRestypeHardlink.RestypeQuery Restype { get; init; }
    internal ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsVersionHeader XMsVersion { get; init; }
    internal required ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsTypeHeader XMsType { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal required Corvus.Json.JsonString XMsFileTargetFile { get; init; }
    internal ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Restype = request.Bind<ShareNameDirectoryFileNameRestypeHardlink.RestypeQuery>("""
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "hardlink"
  ]
}
"""),
            Timeout = request.Bind<ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsVersionHeader>("""
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
            XMsType = request.Bind<ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsTypeHeader>("""
{
  "in": "header",
  "name": "x-ms-type",
  "description": "Dummy constant parameter, file type can only be file.",
  "required": true,
  "type": "string",
  "enum": [
    "file"
  ],
  "x-ms-client-name": "fileTypeConstant",
  "x-ms-parameter-location": "method"
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
            XMsFileTargetFile = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-target-file",
  "description": "NFS only. Required. Specifies the path of the target file to which the link will be created, up to 2 KiB in length. It should be full path of the target from the root.The target file must be in the same share and hence the same storage account.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "targetFile",
  "x-ms-parameter-location": "method"
}
"""),
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.XMsFileRequestIntentHeader>("""
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


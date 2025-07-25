﻿using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameDirectoryFilenameCompRangelist.FileGetrangelist;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString Filename { get; init; }
    internal required SharenameDirectoryFilenameCompRangelist.CompQuery Comp { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal Corvus.Json.JsonString? Prevsharesnapshot { get; init; }
    internal SharenameDirectoryFilenameCompRangelist.FileGetrangelist.TimeoutQuery? Timeout { get; init; }
    internal required SharenameDirectoryFilenameCompRangelist.FileGetrangelist.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsRange { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal SharenameDirectoryFilenameCompRangelist.FileGetrangelist.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileSupportRename { get; init; }

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
            Comp = request.Bind<SharenameDirectoryFilenameCompRangelist.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "rangelist"
  ]
}
"""),
            Sharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Prevsharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "prevsharesnapshot",
  "description": "The previous snapshot parameter is an opaque DateTime value that, when present, specifies the previous snapshot.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = request.Bind<SharenameDirectoryFilenameCompRangelist.FileGetrangelist.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameDirectoryFilenameCompRangelist.FileGetrangelist.XMsVersionHeader>("""
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
            XMsRange = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-range",
  "description": "Specifies the range of bytes over which to list ranges, inclusively.",
  "type": "string",
  "x-ms-client-name": "range"
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
            XMsAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<SharenameDirectoryFilenameCompRangelist.FileGetrangelist.XMsFileRequestIntentHeader>("""
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
            XMsFileSupportRename = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-file-support-rename",
  "description": "This header is allowed only when PrevShareSnapshot query parameter is set. Determines whether the changed ranges for a file that has been renamed or moved between the target snapshot (or the live file) and the previous snapshot should be listed. If the value is true, the valid changed ranges for the file will be returned. If the value is false, the operation will result in a failure with 409 (Conflict) response. The default value is false.",
  "type": "boolean",
  "x-ms-client-name": "SupportRename",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
        };
    }
}

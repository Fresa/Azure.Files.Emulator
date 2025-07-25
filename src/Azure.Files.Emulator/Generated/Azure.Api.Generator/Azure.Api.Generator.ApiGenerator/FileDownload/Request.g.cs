﻿using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameDirectoryFilename.FileDownload;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString Filename { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal SharenameDirectoryFilename.FileDownload.TimeoutQuery? Timeout { get; init; }
    internal required SharenameDirectoryFilename.FileDownload.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsRange { get; init; }
    internal Corvus.Json.JsonBoolean? XMsRangeGetContentMd5 { get; init; }
    internal Corvus.Json.JsonString? XMsStructuredBody { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal SharenameDirectoryFilename.FileDownload.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            XMsAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            Timeout = request.Bind<SharenameDirectoryFilename.FileDownload.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameDirectoryFilename.FileDownload.XMsVersionHeader>("""
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
  "description": "Return file data only from the specified byte range.",
  "type": "string",
  "x-ms-client-name": "range",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsRangeGetContentMd5 = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-range-get-content-md5",
  "description": "When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.",
  "type": "boolean",
  "x-ms-client-name": "rangeGetContentMD5",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsStructuredBody = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-structured-body",
  "description": "Specifies the response content should be returned as a structured message and specifies the message schema version and properties.",
  "type": "string",
  "x-ms-client-name": "StructuredBodyType",
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
            XMsFileRequestIntent = request.Bind<SharenameDirectoryFilename.FileDownload.XMsFileRequestIntentHeader>("""
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

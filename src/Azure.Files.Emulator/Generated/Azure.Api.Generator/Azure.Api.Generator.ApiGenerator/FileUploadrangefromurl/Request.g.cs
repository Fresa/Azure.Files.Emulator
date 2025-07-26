using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString Filename { get; init; }
    internal required SharenameDirectoryFilenameCompRangeFromurl.CompQuery Comp { get; init; }
    internal SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.TimeoutQuery? Timeout { get; init; }
    internal required Corvus.Json.JsonString XMsRange { get; init; }
    internal required Corvus.Json.JsonString XMsCopySource { get; init; }
    internal Corvus.Json.JsonString? XMsSourceRange { get; init; }
    internal required SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsWriteHeader XMsWrite { get; init; }
    internal required Corvus.Json.JsonInt64 ContentLength { get; init; }
    internal Corvus.Json.JsonString? XMsSourceContentCrc64 { get; init; }
    internal Corvus.Json.JsonString? XMsSourceIfMatchCrc64 { get; init; }
    internal Corvus.Json.JsonString? XMsSourceIfNoneMatchCrc64 { get; init; }
    internal required SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonString? XMsCopySourceAuthorization { get; init; }
    internal SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsFileLastWriteTimeHeader? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSourceAllowTrailingDot { get; init; }
    internal SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "range"
  ]
}
"""),
            Timeout = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsRange = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-range",
  "description": "Writes data to the specified byte range in the file.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "Range",
  "x-ms-parameter-location": "method"
}
"""),
            XMsCopySource = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-copy-source",
  "description": "Specifies the URL of the source file or blob, up to 2 KB in length. To copy a file to another file within the same storage account, you may use Shared Key to authenticate the source file. If you are copying a file from another storage account, or if you are copying a blob from the same storage account or another storage account, then you must authenticate the source file or blob using a shared access signature. If the source is a public blob, no authentication is required to perform the copy operation. A file in a share snapshot can also be specified as a copy source.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "copySource",
  "x-ms-parameter-location": "method"
}
"""),
            XMsSourceRange = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-source-range",
  "description": "Bytes of source data in the specified range.",
  "type": "string",
  "x-ms-client-name": "sourceRange",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsWrite = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsWriteHeader>("""
{
  "in": "header",
  "name": "x-ms-write",
  "description": "Only update is supported: - Update: Writes the bytes downloaded from the source url into the specified range.",
  "required": true,
  "type": "string",
  "default": "update",
  "enum": [
    "update"
  ],
  "x-ms-parameter-location": "client",
  "x-ms-client-name": "fileRangeWriteFromUrl",
  "x-ms-enum": {
    "name": "FileRangeWriteFromUrlType",
    "modelAsString": false
  }
}
"""),
            ContentLength = request.Bind<Corvus.Json.JsonInt64>("""
{
  "in": "header",
  "name": "Content-Length",
  "description": "Specifies the number of bytes being transmitted in the request body. When the x-ms-write header is set to clear, the value of this header must be set to zero.",
  "required": true,
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "contentLength",
  "x-ms-parameter-location": "method"
}
"""),
            XMsSourceContentCrc64 = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-source-content-crc64",
  "description": "Specify the crc64 calculated for the range of bytes that must be read from the copy source.",
  "type": "string",
  "format": "byte",
  "x-ms-client-name": "sourceContentCrc64",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSourceIfMatchCrc64 = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-source-if-match-crc64",
  "description": "Specify the crc64 value to operate only on range with a matching crc64 checksum.",
  "type": "string",
  "format": "byte",
  "x-ms-client-name": "sourceIfMatchCrc64",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "source-modified-access-conditions"
  }
}
""").AsOptional(),
            XMsSourceIfNoneMatchCrc64 = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-source-if-none-match-crc64",
  "description": "Specify the crc64 value to operate only on range without a matching crc64 checksum.",
  "type": "string",
  "format": "byte",
  "x-ms-client-name": "sourceIfNoneMatchCrc64",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "source-modified-access-conditions"
  }
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsVersionHeader>("""
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
            XMsCopySourceAuthorization = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-copy-source-authorization",
  "description": "Only Bearer type is supported. Credentials should be a valid OAuth access token to copy source.",
  "type": "string",
  "x-ms-client-name": "copySourceAuthorization",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileLastWriteTime = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsFileLastWriteTimeHeader>("""
{
  "in": "header",
  "name": "x-ms-file-last-write-time",
  "description": "If the file last write time should be preserved or overwritten",
  "type": "string",
  "enum": [
    "Now",
    "Preserve"
  ],
  "x-ms-client-name": "FileLastWrittenMode",
  "x-ms-parameter-location": "method",
  "x-ms-enum": {
    "name": "FileLastWrittenMode",
    "modelAsString": false
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
            XMsSourceAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-source-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the source URI.",
  "type": "boolean",
  "x-ms-client-name": "allowSourceTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl.XMsFileRequestIntentHeader>("""
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

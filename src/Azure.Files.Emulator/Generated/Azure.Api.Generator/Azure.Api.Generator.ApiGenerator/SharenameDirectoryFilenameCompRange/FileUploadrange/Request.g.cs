using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompRange.FileUploadRange;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required ShareNameDirectoryFileNameCompRange.CompQuery Comp { get; init; }
    internal ShareNameDirectoryFileNameCompRange.FileUploadRange.TimeoutQuery? Timeout { get; init; }
    internal required Corvus.Json.JsonString XMsRange { get; init; }
    internal required ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsWriteHeader XMsWrite { get; init; }
    internal required Corvus.Json.JsonInt64 ContentLength { get; init; }
    internal Corvus.Json.JsonString? ContentMD5 { get; init; }
    internal required ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsFileLastWriteTimeHeader? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsStructuredBody { get; init; }
    internal Corvus.Json.JsonInt64? XMsStructuredContentLength { get; init; }

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
            Comp = request.Bind<ShareNameDirectoryFileNameCompRange.CompQuery>("""
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
            Timeout = request.Bind<ShareNameDirectoryFileNameCompRange.FileUploadRange.TimeoutQuery>("""
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
  "description": "Specifies the range of bytes to be written. Both the start and end of the range must be specified. For an update operation, the range can be up to 4 MB in size. For a clear operation, the range can be up to the value of the file's full size. The File service accepts only a single byte range for the Range and 'x-ms-range' headers, and the byte range must be specified in the following format: bytes=startByte-endByte.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "range"
}
"""),
            XMsWrite = request.Bind<ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsWriteHeader>("""
{
  "in": "header",
  "name": "x-ms-write",
  "description": "Specify one of the following options: - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update. - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and set the Range header to a value that indicates the range to clear, up to maximum file size.",
  "required": true,
  "type": "string",
  "default": "update",
  "enum": [
    "update",
    "clear"
  ],
  "x-ms-client-name": "FileRangeWrite",
  "x-ms-enum": {
    "name": "FileRangeWriteType",
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
            ContentMD5 = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "Content-MD5",
  "description": "An MD5 hash of the content. This hash is used to verify the integrity of the data during transport. When the Content-MD5 header is specified, the File service compares the hash of the content that has arrived with the header value that was sent. If the two hashes do not match, the operation will fail with error code 400 (Bad Request).",
  "type": "string",
  "format": "byte",
  "x-ms-client-name": "contentMD5",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsVersionHeader>("""
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
            XMsFileLastWriteTime = request.Bind<ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsFileLastWriteTimeHeader>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryFileNameCompRange.FileUploadRange.XMsFileRequestIntentHeader>("""
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
            XMsStructuredBody = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-structured-body",
  "description": "Required if the request body is a structured message. Specifies the message schema version and properties.",
  "type": "string",
  "x-ms-client-name": "StructuredBodyType",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsStructuredContentLength = request.Bind<Corvus.Json.JsonInt64>("""
{
  "in": "header",
  "name": "x-ms-structured-content-length",
  "description": "Required if the request body is a structured message. Specifies the length of the blob/file content inside the message body. Will always be smaller than Content-Length.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "StructuredContentLength",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
        };
    }
}

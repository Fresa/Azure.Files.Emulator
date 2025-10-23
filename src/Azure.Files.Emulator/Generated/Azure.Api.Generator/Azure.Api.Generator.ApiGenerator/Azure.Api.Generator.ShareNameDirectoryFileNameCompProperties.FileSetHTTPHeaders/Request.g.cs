#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.CompQuery Comp { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonInt64? XMsContentLength { get; init; }
    internal Corvus.Json.JsonString? XMsContentType { get; init; }
    internal Corvus.Json.JsonString? XMsContentEncoding { get; init; }
    internal Corvus.Json.JsonString? XMsContentLanguage { get; init; }
    internal Corvus.Json.JsonString? XMsCacheControl { get; init; }
    internal Corvus.Json.JsonString? XMsContentMd5 { get; init; }
    internal Corvus.Json.JsonString? XMsContentDisposition { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermission { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermissionKey { get; init; }
    internal Corvus.Json.JsonString? XMsFileAttributes { get; init; }
    internal Corvus.Json.JsonString? XMsFileCreationTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileChangeTime { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsOwner { get; init; }
    internal Corvus.Json.JsonString? XMsGroup { get; init; }
    internal Corvus.Json.JsonString? XMsMode { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
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
            FileName = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "properties"
  ]
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsVersionHeader>(request, """
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
            XMsContentLength = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(request, """
{
  "in": "header",
  "name": "x-ms-content-length",
  "description": "Resizes a file to the specified size. If the specified byte value is less than the current size of the file, then all ranges above the specified byte value are cleared.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "fileContentLength"
}
""").AsOptional(),
            XMsContentType = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-content-type",
  "description": "Sets the MIME content type of the file. The default type is 'application/octet-stream'.",
  "type": "string",
  "x-ms-client-name": "fileContentType",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsContentEncoding = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-content-encoding",
  "description": "Specifies which content encodings have been applied to the file.",
  "type": "string",
  "x-ms-client-name": "fileContentEncoding",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsContentLanguage = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-content-language",
  "description": "Specifies the natural languages used by this resource.",
  "type": "string",
  "x-ms-client-name": "fileContentLanguage",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsCacheControl = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-cache-control",
  "description": "Sets the file's cache control. The File service stores this value but does not use or modify it.",
  "type": "string",
  "x-ms-client-name": "fileCacheControl",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsContentMd5 = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-content-md5",
  "description": "Sets the file's MD5 hash.",
  "type": "string",
  "format": "byte",
  "x-ms-client-name": "fileContentMD5",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsContentDisposition = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-content-disposition",
  "description": "Sets the file's Content-Disposition header.",
  "type": "string",
  "x-ms-client-name": "fileContentDisposition",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "file-HTTP-headers"
  }
}
""").AsOptional(),
            XMsFilePermission = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-file-permission",
  "description": "If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is <= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.",
  "type": "string",
  "x-ms-client-name": "FilePermission",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFilePermissionFormat = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsFilePermissionFormatHeader>(request, """
{
  "in": "header",
  "name": "x-ms-file-permission-format",
  "description": "Optional. Available for version 2023-06-01 and later. Specifies the format in which the permission is returned. Acceptable values are SDDL or binary. If x-ms-file-permission-format is unspecified or explicitly set to SDDL, the permission is returned in SDDL format. If x-ms-file-permission-format is explicitly set to binary, the permission is returned as a base64 string representing the binary encoding of the permission",
  "type": "string",
  "enum": [
    "Sddl",
    "Binary"
  ],
  "x-ms-client-name": "FilePermissionFormat",
  "x-ms-parameter-location": "method",
  "x-ms-enum": {
    "name": "FilePermissionFormat",
    "modelAsString": false
  }
}
""").AsOptional(),
            XMsFilePermissionKey = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-file-permission-key",
  "description": "Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.",
  "type": "string",
  "x-ms-client-name": "FilePermissionKey",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileAttributes = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-file-attributes",
  "description": "If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.",
  "type": "string",
  "x-ms-client-name": "FileAttributes",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileCreationTime = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsFileLastWriteTime = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsFileChangeTime = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-file-change-time",
  "description": "Change time for the file/directory. Default value: Now.",
  "type": "string",
  "format": "date-time-rfc1123",
  "x-ms-client-name": "FileChangeTime",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseId = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsAllowTrailingDot = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.XMsFileRequestIntentHeader>(request, """
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
            XMsOwner = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-owner",
  "description": "Optional, NFS only. The owner of the file or directory.",
  "type": "string",
  "x-ms-client-name": "owner",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsGroup = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-group",
  "description": "Optional, NFS only. The owning group of the file or directory.",
  "type": "string",
  "x-ms-client-name": "group",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsMode = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-mode",
  "description": "Optional, NFS only. The file mode of the file or directory",
  "type": "string",
  "x-ms-client-name": "fileMode",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
        };
    }
}
#nullable restore


#nullable enable
using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompProperties.RestypeQuery Restype { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompProperties.CompQuery Comp { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermission { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermissionKey { get; init; }
    internal Corvus.Json.JsonString? XMsFileAttributes { get; init; }
    internal Corvus.Json.JsonString? XMsFileCreationTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileChangeTime { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsOwner { get; init; }
    internal Corvus.Json.JsonString? XMsGroup { get; init; }
    internal Corvus.Json.JsonString? XMsMode { get; init; }

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
            Restype = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.RestypeQuery>("""
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
            Comp = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.CompQuery>("""
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
            Timeout = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsVersionHeader>("""
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
            XMsFilePermission = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-permission",
  "description": "If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is <= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.",
  "type": "string",
  "x-ms-client-name": "FilePermission",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFilePermissionFormat = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsFilePermissionFormatHeader>("""
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
            XMsFilePermissionKey = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-permission-key",
  "description": "Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.",
  "type": "string",
  "x-ms-client-name": "FilePermissionKey",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileAttributes = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-attributes",
  "description": "If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.",
  "type": "string",
  "x-ms-client-name": "FileAttributes",
  "x-ms-parameter-location": "method"
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
            XMsFileChangeTime = request.Bind<Corvus.Json.JsonString>("""
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
            XMsAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.XMsFileRequestIntentHeader>("""
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
            XMsMode = request.Bind<Corvus.Json.JsonString>("""
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


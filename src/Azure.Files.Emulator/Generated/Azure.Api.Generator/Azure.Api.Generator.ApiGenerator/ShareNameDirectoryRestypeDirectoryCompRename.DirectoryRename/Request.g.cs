#nullable enable
using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompRename.RestypeQuery Restype { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompRename.CompQuery Comp { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsVersionHeader XMsVersion { get; init; }
    internal required Corvus.Json.JsonString XMsFileRenameSource { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileRenameReplaceIfExists { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileRenameIgnoreReadonly { get; init; }
    internal Corvus.Json.JsonString? XMsSourceLeaseId { get; init; }
    internal Corvus.Json.JsonString? XMsDestinationLeaseId { get; init; }
    internal Corvus.Json.JsonString? XMsFileAttributes { get; init; }
    internal Corvus.Json.JsonString? XMsFileCreationTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileChangeTime { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermission { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermissionKey { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSourceAllowTrailingDot { get; init; }
    internal ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Restype = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.RestypeQuery>("""
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
            Comp = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "rename"
  ]
}
"""),
            Timeout = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsVersionHeader>("""
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
            XMsFileRenameSource = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-rename-source",
  "description": "Required. Specifies the URI-style path of the source file, up to 2 KB in length.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "renameSource",
  "x-ms-parameter-location": "method"
}
"""),
            XMsFileRenameReplaceIfExists = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-file-rename-replace-if-exists",
  "description": "Optional. A boolean value for if the destination file already exists, whether this request will overwrite the file or not. If true, the rename will succeed and will overwrite the destination file. If not provided or if false and the destination file does exist, the request will not overwrite the destination file. If provided and the destination file doesn’t exist, the rename will succeed. Note: This value does not override the x-ms-file-copy-ignore-read-only header value.",
  "type": "boolean",
  "x-ms-client-name": "replaceIfExists",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileRenameIgnoreReadonly = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-file-rename-ignore-readonly",
  "description": "Optional. A boolean value that specifies whether the ReadOnly attribute on a preexisting destination file should be respected. If true, the rename will succeed, otherwise, a previous file at the destination with the ReadOnly attribute set will cause the rename to fail.",
  "type": "boolean",
  "x-ms-client-name": "ignoreReadOnly",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSourceLeaseId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-source-lease-id",
  "description": "Required if the source file has an active infinite lease.",
  "type": "string",
  "x-ms-client-name": "sourceLeaseId",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "source-lease-access-conditions"
  }
}
""").AsOptional(),
            XMsDestinationLeaseId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-destination-lease-id",
  "description": "Required if the destination file has an active infinite lease. The lease ID specified for this header must match the lease ID of the destination file. If the request does not include the lease ID or it is not valid, the operation fails with status code 412 (Precondition Failed). If this header is specified and the destination file does not currently have an active lease, the operation will also fail with status code 412 (Precondition Failed).",
  "type": "string",
  "x-ms-client-name": "destinationLeaseId",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "destination-lease-access-conditions"
  }
}
""").AsOptional(),
            XMsFileAttributes = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-attributes",
  "description": "Specifies either the option to copy file attributes from a source file(source) to a target file or a list of attributes to set on a target file.",
  "type": "string",
  "x-ms-client-name": "fileAttributes",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
}
""").AsOptional(),
            XMsFileCreationTime = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-creation-time",
  "description": "Specifies either the option to copy file creation time from a source file(source) to a target file or a time value in ISO 8601 format to set as creation time on a target file.",
  "type": "string",
  "x-ms-client-name": "fileCreationTime",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
}
""").AsOptional(),
            XMsFileLastWriteTime = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-last-write-time",
  "description": "Specifies either the option to copy file last write time from a source file(source) to a target file or a time value in ISO 8601 format to set as last write time on a target file.",
  "type": "string",
  "x-ms-client-name": "fileLastWriteTime",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
}
""").AsOptional(),
            XMsFileChangeTime = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-file-change-time",
  "description": "Specifies either the option to copy file last write time from a source file(source) to a target file or a time value in ISO 8601 format to set as last write time on a target file.",
  "type": "string",
  "x-ms-client-name": "fileChangeTime",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
}
""").AsOptional(),
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
            XMsFilePermissionFormat = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsFilePermissionFormatHeader>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.XMsFileRequestIntentHeader>("""
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


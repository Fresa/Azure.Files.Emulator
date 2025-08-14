using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompCopy.FileStartCopy;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal required Corvus.Json.JsonString XMsCopySource { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermission { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal Corvus.Json.JsonString? XMsFilePermissionKey { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFilePermissionCopyModeHeader? XMsFilePermissionCopyMode { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileCopyIgnoreReadonly { get; init; }
    internal Corvus.Json.JsonString? XMsFileAttributes { get; init; }
    internal Corvus.Json.JsonString? XMsFileCreationTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileLastWriteTime { get; init; }
    internal Corvus.Json.JsonString? XMsFileChangeTime { get; init; }
    internal Corvus.Json.JsonBoolean? XMsFileCopySetArchive { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSourceAllowTrailingDot { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsOwner { get; init; }
    internal Corvus.Json.JsonString? XMsGroup { get; init; }
    internal Corvus.Json.JsonString? XMsMode { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileModeCopyModeHeader? XMsFileModeCopyMode { get; init; }
    internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileOwnerCopyModeHeader? XMsFileOwnerCopyMode { get; init; }

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
            Timeout = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsVersionHeader>("""
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
            XMsFilePermissionFormat = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFilePermissionFormatHeader>("""
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
            XMsFilePermissionCopyMode = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFilePermissionCopyModeHeader>("""
{
  "in": "header",
  "name": "x-ms-file-permission-copy-mode",
  "description": "Specifies the option to copy file security descriptor from source file or to set it using the value which is defined by the header value of x-ms-file-permission or x-ms-file-permission-key.",
  "type": "string",
  "enum": [
    "source",
    "override"
  ],
  "x-ms-client-name": "filePermissionCopyMode",
  "x-ms-enum": {
    "name": "PermissionCopyModeType",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
}
""").AsOptional(),
            XMsFileCopyIgnoreReadonly = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-file-copy-ignore-readonly",
  "description": "Specifies the option to overwrite the target file if it already exists and has read-only attribute set.",
  "type": "boolean",
  "x-ms-client-name": "ignoreReadOnly",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
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
            XMsFileCopySetArchive = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-file-copy-set-archive",
  "description": "Specifies the option to set archive attribute on a target file. True means archive attribute will be set on a target file despite attribute overrides or a source file state.",
  "type": "boolean",
  "x-ms-client-name": "setArchiveAttribute",
  "x-ms-parameter-location": "method",
  "x-ms-parameter-grouping": {
    "name": "copy-file-smb-info"
  }
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
            XMsSourceAllowTrailingDot = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-source-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the source URI.",
  "type": "boolean",
  "x-ms-client-name": "allowSourceTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileRequestIntentHeader>("""
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
            XMsFileModeCopyMode = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileModeCopyModeHeader>("""
{
  "in": "header",
  "name": "x-ms-file-mode-copy-mode",
  "description": "NFS only. Applicable only when the copy source is a File. Determines the copy behavior of the mode bits of the file. source: The mode on the destination file is copied from the source file. override: The mode on the destination file is determined via the x-ms-mode header.",
  "type": "string",
  "enum": [
    "source",
    "override"
  ],
  "x-ms-client-name": "fileModeCopyMode",
  "x-ms-enum": {
    "name": "ModeCopyMode",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileOwnerCopyMode = request.Bind<ShareNameDirectoryFileNameCompCopy.FileStartCopy.XMsFileOwnerCopyModeHeader>("""
{
  "in": "header",
  "name": "x-ms-file-owner-copy-mode",
  "description": "NFS only. Determines the copy behavior of the owner user identifier (UID) and group identifier (GID) of the file. source: The owner user identifier (UID) and group identifier (GID) on the destination file is copied from the source file. override: The owner user identifier (UID) and group identifier (GID) on the destination file is determined via the x-ms-owner and x-ms-group  headers.",
  "type": "string",
  "enum": [
    "source",
    "override"
  ],
  "x-ms-client-name": "fileOwnerCopyMode",
  "x-ms-enum": {
    "name": "OwnerCopyMode",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
        };
    }
}

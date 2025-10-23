#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.CompQuery Comp { get; init; }
    internal required Corvus.Json.JsonString XMsFilePermissionKey { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsVersionHeader XMsVersion { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.RestypeQuery>(request, """
{
  "in": "query",
  "name": "restype",
  "description": "restype",
  "required": true,
  "type": "string",
  "enum": [
    "share"
  ]
}
"""),
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "filepermission"
  ]
}
"""),
            XMsFilePermissionKey = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-file-permission-key",
  "description": "Key of the permission to be set for the directory/file.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "FilePermissionKey",
  "x-ms-parameter-location": "method"
}
"""),
            XMsFilePermissionFormat = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFilePermissionFormatHeader>(request, """
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
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsVersionHeader>(request, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFileRequestIntentHeader>(request, """
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


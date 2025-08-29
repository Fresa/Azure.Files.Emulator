using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompFilepermission.ShareCreatePermission;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required ShareNameRestypeShareCompFilepermission.RestypeQuery Restype { get; init; }
    internal required ShareNameRestypeShareCompFilepermission.CompQuery Comp { get; init; }
    internal required Corvus.Json.JsonString XMsFilePermissionKey { get; init; }
    internal ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFilePermissionFormatHeader? XMsFilePermissionFormat { get; init; }
    internal ShareNameRestypeShareCompFilepermission.ShareCreatePermission.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameRestypeShareCompFilepermission.ShareCreatePermission.XMsVersionHeader XMsVersion { get; init; }
    internal ShareNameRestypeShareCompFilepermission.ShareCreatePermission.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal required RequestContent? Body { get; init; }

    internal sealed class RequestContent
    {
        internal ShareNameRestypeShareCompFilepermission.ShareCreatePermission.RequestBodies.ApplicationXml? ApplicationXml { get; private set; }

        internal static RequestContent? Bind(HttpRequest request)
        {
            var content = new RequestContent();
            var contentType = request.ContentType;
            switch (contentType)
            {
                case "application/xml":
                    content.ApplicationXml = request.BindBody<ShareNameRestypeShareCompFilepermission.ShareCreatePermission.RequestBodies.ApplicationXml>().AsOptional();
                    break;
                default:
                    throw new BadHttpRequestException($"Request body does not support content type {contentType}");
            }

            return content;
        }
    }

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
            Restype = request.Bind<ShareNameRestypeShareCompFilepermission.RestypeQuery>("""
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
            Comp = request.Bind<ShareNameRestypeShareCompFilepermission.CompQuery>("""
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
            XMsFilePermissionKey = request.Bind<Corvus.Json.JsonString>("""
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
            XMsFilePermissionFormat = request.Bind<ShareNameRestypeShareCompFilepermission.ShareGetPermission.XMsFilePermissionFormatHeader>("""
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
            Timeout = request.Bind<ShareNameRestypeShareCompFilepermission.ShareCreatePermission.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameRestypeShareCompFilepermission.ShareCreatePermission.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<ShareNameRestypeShareCompFilepermission.ShareCreatePermission.XMsFileRequestIntentHeader>("""
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
            Body = RequestContent.Bind(request)
        };
    }
}

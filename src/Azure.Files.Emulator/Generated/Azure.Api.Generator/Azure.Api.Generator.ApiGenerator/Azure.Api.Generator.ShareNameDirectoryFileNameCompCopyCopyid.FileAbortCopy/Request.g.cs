#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.CompQuery Comp { get; init; }
    internal required Corvus.Json.JsonString Copyid { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsCopyActionHeader XMsCopyAction { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "copy"
  ]
}
"""),
            Copyid = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "query",
  "name": "copyid",
  "description": "The copy identifier provided in the x-ms-copy-id header of the original Copy File operation.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "copyId",
  "x-ms-parameter-location": "method"
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsCopyAction = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsCopyActionHeader>(request, """
{
  "in": "header",
  "name": "x-ms-copy-action",
  "description": "Abort.",
  "required": true,
  "type": "string",
  "enum": [
    "abort"
  ],
  "x-ms-client-name": "copyActionAbortConstant",
  "x-ms-parameter-location": "method"
}
"""),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsVersionHeader>(request, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.XMsFileRequestIntentHeader>(request, """
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


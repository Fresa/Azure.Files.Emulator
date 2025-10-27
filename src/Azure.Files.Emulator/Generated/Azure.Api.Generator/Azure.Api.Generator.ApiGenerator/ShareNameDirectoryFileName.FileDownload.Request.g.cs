#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload;
internal partial class Request
{
    internal required HttpContext HttpContext { get; init; }
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsRange { get; init; }
    internal Corvus.Json.JsonBoolean? XMsRangeGetContentMd5 { get; init; }
    internal Corvus.Json.JsonString? XMsStructuredBody { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Task<Request> BindAsync(HttpContext context, CancellationToken cancellationToken)
    {
        var httpRequest = context.Request;
        var request = new Request
        {
            HttpContext = context,
            ShareName = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Directory = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
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
            FileName = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
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
            XMsAllowTrailingDot = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.TimeoutQuery>(httpRequest, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.XMsVersionHeader>(httpRequest, """
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
            XMsRange = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-range",
  "description": "Return file data only from the specified byte range.",
  "type": "string",
  "x-ms-client-name": "range",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsRangeGetContentMd5 = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-range-get-content-md5",
  "description": "When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.",
  "type": "boolean",
  "x-ms-client-name": "rangeGetContentMD5",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsStructuredBody = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-structured-body",
  "description": "Specifies the response content should be returned as a structured message and specifies the message schema version and properties.",
  "type": "string",
  "x-ms-client-name": "StructuredBodyType",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseId = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(httpRequest, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.XMsFileRequestIntentHeader>(httpRequest, """
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
        return Task.FromResult(request);
    }
}
#nullable restore


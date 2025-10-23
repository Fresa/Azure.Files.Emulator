#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.CompQuery Comp { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.RestypeQuery>(request, """
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
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "metadata"
  ]
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsMeta = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.XMsVersionHeader>(request, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.XMsFileRequestIntentHeader>(request, """
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


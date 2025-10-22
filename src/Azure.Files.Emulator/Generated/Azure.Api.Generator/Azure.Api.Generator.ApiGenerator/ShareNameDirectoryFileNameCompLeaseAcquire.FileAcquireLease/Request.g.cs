#nullable enable
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Corvus.Json.JsonString Directory { get; init; }
    internal required Corvus.Json.JsonString FileName { get; init; }
    internal required ShareNameDirectoryFileNameCompLeaseAcquire.CompQuery Comp { get; init; }
    internal required ShareNameDirectoryFileNameCompLeaseAcquire.XMsLeaseActionHeader XMsLeaseAction { get; init; }
    internal ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonInteger? XMsLeaseDuration { get; init; }
    internal Corvus.Json.JsonString? XMsProposedLeaseId { get; init; }
    internal required ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal Corvus.Json.JsonBoolean? XMsAllowTrailingDot { get; init; }
    internal ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            ShareName = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Directory = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            FileName = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            Comp = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameDirectoryFileNameCompLeaseAcquire.CompQuery>(request, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "lease"
  ]
}
"""),
            XMsLeaseAction = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameDirectoryFileNameCompLeaseAcquire.XMsLeaseActionHeader>(request, """
{
  "in": "header",
  "name": "x-ms-lease-action",
  "description": "Describes what lease action to take.",
  "required": true,
  "type": "string",
  "enum": [
    "acquire"
  ],
  "x-ms-client-name": "action",
  "x-ms-enum": {
    "name": "LeaseAction",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
"""),
            Timeout = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseDuration = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonInteger>(request, """
{
  "in": "header",
  "name": "x-ms-lease-duration",
  "description": "Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.",
  "type": "integer",
  "x-ms-client-name": "duration",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsProposedLeaseId = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-proposed-lease-id",
  "description": "Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.",
  "type": "string",
  "x-ms-client-name": "proposedLeaseId",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.XMsVersionHeader>(request, """
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
            XMsClientRequestId = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-client-request-id",
  "description": "Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.",
  "type": "string",
  "x-ms-client-name": "requestId",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsAllowTrailingDot = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-allow-trailing-dot",
  "description": "If true, the trailing dot will not be trimmed from the target URI.",
  "type": "boolean",
  "x-ms-client-name": "allowTrailingDot"
}
""").AsOptional(),
            XMsFileRequestIntent = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.XMsFileRequestIntentHeader>(request, """
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


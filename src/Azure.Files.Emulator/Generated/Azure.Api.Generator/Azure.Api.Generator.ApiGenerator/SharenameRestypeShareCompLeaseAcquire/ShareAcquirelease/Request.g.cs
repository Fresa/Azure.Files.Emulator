using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required ShareNameRestypeShareCompLeaseAcquire.CompQuery Comp { get; init; }
    internal required ShareNameRestypeShareCompLeaseAcquire.XMsLeaseActionHeader XMsLeaseAction { get; init; }
    internal required ShareNameRestypeShareCompLeaseAcquire.RestypeQuery Restype { get; init; }
    internal ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonInteger? XMsLeaseDuration { get; init; }
    internal Corvus.Json.JsonString? XMsProposedLeaseId { get; init; }
    internal required ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = request.Bind<ShareNameRestypeShareCompLeaseAcquire.CompQuery>("""
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
            XMsLeaseAction = request.Bind<ShareNameRestypeShareCompLeaseAcquire.XMsLeaseActionHeader>("""
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
            Restype = request.Bind<ShareNameRestypeShareCompLeaseAcquire.RestypeQuery>("""
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
            Timeout = request.Bind<ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseDuration = request.Bind<Corvus.Json.JsonInteger>("""
{
  "in": "header",
  "name": "x-ms-lease-duration",
  "description": "Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.",
  "type": "integer",
  "x-ms-client-name": "duration",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsProposedLeaseId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-proposed-lease-id",
  "description": "Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.",
  "type": "string",
  "x-ms-client-name": "proposedLeaseId",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.XMsVersionHeader>("""
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
            Sharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsClientRequestId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-client-request-id",
  "description": "Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.",
  "type": "string",
  "x-ms-client-name": "requestId",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.XMsFileRequestIntentHeader>("""
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

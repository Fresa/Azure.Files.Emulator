using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameRestypeShareCompLeaseBreak.ShareBreaklease;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required SharenameRestypeShareCompLeaseBreak.CompQuery Comp { get; init; }
    internal required SharenameRestypeShareCompLeaseBreak.XMsLeaseActionHeader XMsLeaseAction { get; init; }
    internal required SharenameRestypeShareCompLeaseBreak.RestypeQuery Restype { get; init; }
    internal SharenameRestypeShareCompLeaseBreak.ShareBreaklease.TimeoutQuery? Timeout { get; init; }
    internal Corvus.Json.JsonInteger? XMsLeaseBreakPeriod { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal required SharenameRestypeShareCompLeaseBreak.ShareBreaklease.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal SharenameRestypeShareCompLeaseBreak.ShareBreaklease.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            Sharename = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "path",
  "name": "shareName",
  "description": "The name of the target share.",
  "required": true,
  "type": "string",
  "x-ms-parameter-location": "method"
}
"""),
            Comp = request.Bind<SharenameRestypeShareCompLeaseBreak.CompQuery>("""
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
            XMsLeaseAction = request.Bind<SharenameRestypeShareCompLeaseBreak.XMsLeaseActionHeader>("""
{
  "in": "header",
  "name": "x-ms-lease-action",
  "description": "Describes what lease action to take.",
  "required": true,
  "type": "string",
  "enum": [
    "break"
  ],
  "x-ms-client-name": "action",
  "x-ms-enum": {
    "name": "LeaseAction",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
"""),
            Restype = request.Bind<SharenameRestypeShareCompLeaseBreak.RestypeQuery>("""
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
            Timeout = request.Bind<SharenameRestypeShareCompLeaseBreak.ShareBreaklease.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseBreakPeriod = request.Bind<Corvus.Json.JsonInteger>("""
{
  "in": "header",
  "name": "x-ms-lease-break-period",
  "description": "For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.",
  "type": "integer",
  "x-ms-client-name": "breakPeriod",
  "x-ms-parameter-location": "method"
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
            XMsVersion = request.Bind<SharenameRestypeShareCompLeaseBreak.ShareBreaklease.XMsVersionHeader>("""
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
            Sharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsFileRequestIntent = request.Bind<SharenameRestypeShareCompLeaseBreak.ShareBreaklease.XMsFileRequestIntentHeader>("""
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

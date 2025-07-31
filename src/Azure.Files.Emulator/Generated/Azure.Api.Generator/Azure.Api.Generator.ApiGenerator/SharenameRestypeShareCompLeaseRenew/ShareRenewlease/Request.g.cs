using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameRestypeShareCompLeaseRenew.ShareRenewlease;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required SharenameRestypeShareCompLeaseRenew.CompQuery Comp { get; init; }
    internal required SharenameRestypeShareCompLeaseRenew.XMsLeaseActionHeader XMsLeaseAction { get; init; }
    internal required SharenameRestypeShareCompLeaseRenew.RestypeQuery Restype { get; init; }
    internal SharenameRestypeShareCompLeaseRenew.ShareRenewlease.TimeoutQuery? Timeout { get; init; }
    internal required Corvus.Json.JsonString XMsLeaseId { get; init; }
    internal required SharenameRestypeShareCompLeaseRenew.ShareRenewlease.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal Corvus.Json.JsonString? XMsClientRequestId { get; init; }
    internal SharenameRestypeShareCompLeaseRenew.ShareRenewlease.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

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
            Comp = request.Bind<SharenameRestypeShareCompLeaseRenew.CompQuery>("""
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
            XMsLeaseAction = request.Bind<SharenameRestypeShareCompLeaseRenew.XMsLeaseActionHeader>("""
{
  "in": "header",
  "name": "x-ms-lease-action",
  "description": "Describes what lease action to take.",
  "required": true,
  "type": "string",
  "enum": [
    "renew"
  ],
  "x-ms-client-name": "action",
  "x-ms-enum": {
    "name": "LeaseAction",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
"""),
            Restype = request.Bind<SharenameRestypeShareCompLeaseRenew.RestypeQuery>("""
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
            Timeout = request.Bind<SharenameRestypeShareCompLeaseRenew.ShareRenewlease.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsLeaseId = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-lease-id",
  "description": "Specifies the current lease ID on the resource.",
  "required": true,
  "type": "string",
  "x-ms-client-name": "leaseId",
  "x-ms-parameter-location": "method"
}
"""),
            XMsVersion = request.Bind<SharenameRestypeShareCompLeaseRenew.ShareRenewlease.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<SharenameRestypeShareCompLeaseRenew.ShareRenewlease.XMsFileRequestIntentHeader>("""
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

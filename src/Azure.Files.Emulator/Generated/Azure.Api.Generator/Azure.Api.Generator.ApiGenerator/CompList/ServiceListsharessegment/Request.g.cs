using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace CompList.ServiceListSharesSegment;
internal partial class Request
{
    internal required CompList.CompQuery Comp { get; init; }
    internal Corvus.Json.JsonString? Prefix { get; init; }
    internal Corvus.Json.JsonString? Marker { get; init; }
    internal CompList.ServiceListSharesSegment.MaxresultsQuery? Maxresults { get; init; }
    internal CompList.ServiceListSharesSegment.IncludeQuery? Include { get; init; }
    internal CompList.ServiceListSharesSegment.TimeoutQuery? Timeout { get; init; }
    internal required CompList.ServiceListSharesSegment.XMsVersionHeader XMsVersion { get; init; }
    internal CompList.ServiceListSharesSegment.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }

    public static Request Bind(HttpRequest request)
    {
        return new Request
        {
            Comp = request.Bind<CompList.CompQuery>("""
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "list"
  ]
}
"""),
            Prefix = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "prefix",
  "description": "Filters the results to return only entries whose name begins with the specified prefix.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Marker = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "marker",
  "description": "A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Maxresults = request.Bind<CompList.ServiceListSharesSegment.MaxresultsQuery>("""
{
  "in": "query",
  "name": "maxresults",
  "description": "Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.",
  "type": "integer",
  "minimum": 1,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Include = request.Bind<CompList.ServiceListSharesSegment.IncludeQuery>("""
{
  "in": "query",
  "name": "include",
  "description": "Include this parameter to specify one or more datasets to include in the response.",
  "type": "array",
  "items": {
    "type": "string",
    "enum": [
      "snapshots",
      "metadata",
      "deleted"
    ],
    "x-ms-enum": {
      "name": "ListSharesIncludeType",
      "modelAsString": false
    }
  },
  "collectionFormat": "multi",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = request.Bind<CompList.ServiceListSharesSegment.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<CompList.ServiceListSharesSegment.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<CompList.ServiceListSharesSegment.XMsFileRequestIntentHeader>("""
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

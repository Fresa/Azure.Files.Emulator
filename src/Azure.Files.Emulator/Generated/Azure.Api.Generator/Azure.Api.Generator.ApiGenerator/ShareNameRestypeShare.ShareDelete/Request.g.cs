#nullable enable
using Corvus.Json;

namespace ShareNameRestypeShare.ShareDelete;
internal partial class Request
{
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required ShareNameRestypeShare.RestypeQuery Restype { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal ShareNameRestypeShare.ShareDelete.TimeoutQuery? Timeout { get; init; }
    internal required ShareNameRestypeShare.ShareDelete.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal ShareNameRestypeShare.ShareDelete.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal ShareNameRestypeShare.ShareCreate.XMsShareQuotaHeader? XMsShareQuota { get; init; }
    internal ShareNameRestypeShare.ShareCreate.XMsAccessTierHeader? XMsAccessTier { get; init; }
    internal Corvus.Json.JsonString? XMsEnabledProtocols { get; init; }
    internal ShareNameRestypeShare.ShareCreate.XMsRootSquashHeader? XMsRootSquash { get; init; }
    internal Corvus.Json.JsonBoolean? XMsEnableSnapshotVirtualDirectoryAccess { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSharePaidBurstingEnabled { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxBandwidthMibps { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxIops { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedIops { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedBandwidthMibps { get; init; }
    internal ShareNameRestypeShare.ShareDelete.XMsDeleteSnapshotsHeader? XMsDeleteSnapshots { get; init; }

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
            Restype = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.RestypeQuery>(request, """
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
            Sharesnapshot = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareDelete.TimeoutQuery>(request, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareDelete.XMsVersionHeader>(request, """
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
            XMsLeaseId = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsFileRequestIntent = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareDelete.XMsFileRequestIntentHeader>(request, """
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
            XMsMeta = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
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
            XMsShareQuota = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareCreate.XMsShareQuotaHeader>(request, """
{
  "in": "header",
  "name": "x-ms-share-quota",
  "description": "Specifies the maximum size of the share, in gigabytes.",
  "type": "integer",
  "minimum": 1,
  "x-ms-client-name": "quota",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsAccessTier = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareCreate.XMsAccessTierHeader>(request, """
{
  "in": "header",
  "name": "x-ms-access-tier",
  "description": "Specifies the access tier of the share.",
  "type": "string",
  "enum": [
    "TransactionOptimized",
    "Hot",
    "Cool",
    "Premium"
  ],
  "x-ms-client-name": "accessTier",
  "x-ms-parameter-location": "method",
  "x-ms-enum": {
    "name": "ShareAccessTier",
    "modelAsString": true
  }
}
""").AsOptional(),
            XMsEnabledProtocols = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonString>(request, """
{
  "in": "header",
  "name": "x-ms-enabled-protocols",
  "description": "Protocols to enable on the share.",
  "type": "string",
  "x-ms-client-name": "enabledProtocols",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsRootSquash = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareCreate.XMsRootSquashHeader>(request, """
{
  "in": "header",
  "name": "x-ms-root-squash",
  "description": "Root squash to set on the share.  Only valid for NFS shares.",
  "type": "string",
  "enum": [
    "NoRootSquash",
    "RootSquash",
    "AllSquash"
  ],
  "x-ms-client-name": "rootSquash",
  "x-ms-enum": {
    "name": "ShareRootSquash",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsEnableSnapshotVirtualDirectoryAccess = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-enable-snapshot-virtual-directory-access",
  "type": "boolean",
  "x-ms-client-name": "enableSnapshotVirtualDirectoryAccess",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingEnabled = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(request, """
{
  "in": "header",
  "name": "x-ms-share-paid-bursting-enabled",
  "description": "Optional. Boolean. Default if not specified is false. This property enables paid bursting.",
  "type": "boolean",
  "x-ms-client-name": "paidBurstingEnabled",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingMaxBandwidthMibps = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(request, """
{
  "in": "header",
  "name": "x-ms-share-paid-bursting-max-bandwidth-mibps",
  "description": "Optional. Integer. Default if not specified is the maximum throughput the file share can support. Current maximum for a file share is 10,340  MiB/sec.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "PaidBurstingMaxBandwidthMibps",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingMaxIops = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(request, """
{
  "in": "header",
  "name": "x-ms-share-paid-bursting-max-iops",
  "description": "Optional. Integer. Default if not specified is the maximum IOPS the file share can support. Current maximum for a file share is 102,400 IOPS.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "paidBurstingMaxIops",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsShareProvisionedIops = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(request, """
{
  "in": "header",
  "name": "x-ms-share-provisioned-iops",
  "description": "Optional. Supported in version 2025-01-05 and later. Only allowed for provisioned v2 file shares. Specifies the provisioned number of input/output operations per second (IOPS) of the share. If this is not specified, the provisioned IOPS is set to value calculated based on recommendation formula.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "shareProvisionedIops",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsShareProvisionedBandwidthMibps = OpenApiGenerator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(request, """
{
  "in": "header",
  "name": "x-ms-share-provisioned-bandwidth-mibps",
  "description": "Optional. Supported in version 2025-01-05 and later. Only allowed for provisioned v2 file shares. Specifies the provisioned bandwidth of the share, in mebibytes per second (MiBps). If this is not specified, the provisioned bandwidth is set to value calculated based on recommendation formula.",
  "type": "integer",
  "format": "int64",
  "x-ms-client-name": "shareProvisionedBandwidthMibps",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsDeleteSnapshots = OpenApiGenerator.HttpRequestExtensions.Bind<ShareNameRestypeShare.ShareDelete.XMsDeleteSnapshotsHeader>(request, """
{
  "in": "header",
  "name": "x-ms-delete-snapshots",
  "description": "Specifies the option include to delete the base share and all of its snapshots.",
  "type": "string",
  "enum": [
    "include",
    "include-leased"
  ],
  "x-ms-client-name": "deleteSnapshots",
  "x-ms-enum": {
    "name": "DeleteSnapshotsOptionType",
    "modelAsString": false
  },
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
        };
    }
}
#nullable restore


using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace SharenameRestypeShare.ShareDelete;
internal partial class Request
{
    internal required Corvus.Json.JsonString Sharename { get; init; }
    internal required SharenameRestypeShare.RestypeQuery Restype { get; init; }
    internal Corvus.Json.JsonString? Sharesnapshot { get; init; }
    internal SharenameRestypeShare.ShareDelete.TimeoutQuery? Timeout { get; init; }
    internal required SharenameRestypeShare.ShareDelete.XMsVersionHeader XMsVersion { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal SharenameRestypeShare.ShareDelete.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonString? XMsMeta { get; init; }
    internal SharenameRestypeShare.ShareCreate.XMsShareQuotaHeader? XMsShareQuota { get; init; }
    internal SharenameRestypeShare.ShareCreate.XMsAccessTierHeader? XMsAccessTier { get; init; }
    internal Corvus.Json.JsonString? XMsEnabledProtocols { get; init; }
    internal SharenameRestypeShare.ShareCreate.XMsRootSquashHeader? XMsRootSquash { get; init; }
    internal Corvus.Json.JsonBoolean? XMsEnableSnapshotVirtualDirectoryAccess { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSharePaidBurstingEnabled { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxBandwidthMibps { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxIops { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedIops { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedBandwidthMibps { get; init; }
    internal SharenameRestypeShare.ShareDelete.XMsDeleteSnapshotsHeader? XMsDeleteSnapshots { get; init; }

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
            Restype = request.Bind<SharenameRestypeShare.RestypeQuery>("""
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
            Sharesnapshot = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "query",
  "name": "sharesnapshot",
  "description": "The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.",
  "type": "string",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            Timeout = request.Bind<SharenameRestypeShare.ShareDelete.TimeoutQuery>("""
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = request.Bind<SharenameRestypeShare.ShareDelete.XMsVersionHeader>("""
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
            XMsFileRequestIntent = request.Bind<SharenameRestypeShare.ShareDelete.XMsFileRequestIntentHeader>("""
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
            XMsMeta = request.Bind<Corvus.Json.JsonString>("""
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
            XMsShareQuota = request.Bind<SharenameRestypeShare.ShareCreate.XMsShareQuotaHeader>("""
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
            XMsAccessTier = request.Bind<SharenameRestypeShare.ShareCreate.XMsAccessTierHeader>("""
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
            XMsEnabledProtocols = request.Bind<Corvus.Json.JsonString>("""
{
  "in": "header",
  "name": "x-ms-enabled-protocols",
  "description": "Protocols to enable on the share.",
  "type": "string",
  "x-ms-client-name": "enabledProtocols",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsRootSquash = request.Bind<SharenameRestypeShare.ShareCreate.XMsRootSquashHeader>("""
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
            XMsEnableSnapshotVirtualDirectoryAccess = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-enable-snapshot-virtual-directory-access",
  "type": "boolean",
  "x-ms-client-name": "enableSnapshotVirtualDirectoryAccess",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingEnabled = request.Bind<Corvus.Json.JsonBoolean>("""
{
  "in": "header",
  "name": "x-ms-share-paid-bursting-enabled",
  "description": "Optional. Boolean. Default if not specified is false. This property enables paid bursting.",
  "type": "boolean",
  "x-ms-client-name": "paidBurstingEnabled",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingMaxBandwidthMibps = request.Bind<Corvus.Json.JsonInt64>("""
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
            XMsSharePaidBurstingMaxIops = request.Bind<Corvus.Json.JsonInt64>("""
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
            XMsShareProvisionedIops = request.Bind<Corvus.Json.JsonInt64>("""
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
            XMsShareProvisionedBandwidthMibps = request.Bind<Corvus.Json.JsonInt64>("""
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
            XMsDeleteSnapshots = request.Bind<SharenameRestypeShare.ShareDelete.XMsDeleteSnapshotsHeader>("""
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

#nullable enable
using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties;
internal partial class Request
{
    internal required HttpContext HttpContext { get; init; }
    internal required Corvus.Json.JsonString ShareName { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompProperties.RestypeQuery Restype { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompProperties.CompQuery Comp { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.TimeoutQuery? Timeout { get; init; }
    internal required Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsVersionHeader XMsVersion { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsShareQuotaHeader? XMsShareQuota { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsAccessTierHeader? XMsAccessTier { get; init; }
    internal Corvus.Json.JsonString? XMsLeaseId { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsRootSquashHeader? XMsRootSquash { get; init; }
    internal Corvus.Json.JsonBoolean? XMsEnableSnapshotVirtualDirectoryAccess { get; init; }
    internal Corvus.Json.JsonBoolean? XMsSharePaidBurstingEnabled { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxBandwidthMibps { get; init; }
    internal Corvus.Json.JsonInt64? XMsSharePaidBurstingMaxIops { get; init; }
    internal Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsFileRequestIntentHeader? XMsFileRequestIntent { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedIops { get; init; }
    internal Corvus.Json.JsonInt64? XMsShareProvisionedBandwidthMibps { get; init; }

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
            Restype = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.RestypeQuery>(httpRequest, """
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
            Comp = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.CompQuery>(httpRequest, """
{
  "in": "query",
  "name": "comp",
  "description": "comp",
  "required": true,
  "type": "string",
  "enum": [
    "properties"
  ]
}
"""),
            Timeout = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.TimeoutQuery>(httpRequest, """
{
  "in": "query",
  "name": "timeout",
  "description": "The timeout parameter is expressed in seconds. For more information, see <a href=\"https://learn.microsoft.com/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations\">Setting Timeouts for File Service Operations.</a>",
  "type": "integer",
  "minimum": 0,
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsVersion = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsVersionHeader>(httpRequest, """
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
            XMsShareQuota = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsShareQuotaHeader>(httpRequest, """
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
            XMsAccessTier = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsAccessTierHeader>(httpRequest, """
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
            XMsRootSquash = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsRootSquashHeader>(httpRequest, """
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
            XMsEnableSnapshotVirtualDirectoryAccess = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-enable-snapshot-virtual-directory-access",
  "type": "boolean",
  "x-ms-client-name": "enableSnapshotVirtualDirectoryAccess",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingEnabled = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonBoolean>(httpRequest, """
{
  "in": "header",
  "name": "x-ms-share-paid-bursting-enabled",
  "description": "Optional. Boolean. Default if not specified is false. This property enables paid bursting.",
  "type": "boolean",
  "x-ms-client-name": "paidBurstingEnabled",
  "x-ms-parameter-location": "method"
}
""").AsOptional(),
            XMsSharePaidBurstingMaxBandwidthMibps = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(httpRequest, """
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
            XMsSharePaidBurstingMaxIops = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(httpRequest, """
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
            XMsFileRequestIntent = Azure.Files.Emulator.HttpRequestExtensions.Bind<Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.XMsFileRequestIntentHeader>(httpRequest, """
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
            XMsShareProvisionedIops = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(httpRequest, """
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
            XMsShareProvisionedBandwidthMibps = Azure.Files.Emulator.HttpRequestExtensions.Bind<Corvus.Json.JsonInt64>(httpRequest, """
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
        };
        return Task.FromResult(request);
    }
}
#nullable restore


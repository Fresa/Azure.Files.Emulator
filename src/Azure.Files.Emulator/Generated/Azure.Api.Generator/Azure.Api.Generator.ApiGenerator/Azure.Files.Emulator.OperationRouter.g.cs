#nullable enable
namespace Azure.Files.Emulator;
internal static class OperationRouter
{
    internal static WebApplication MapOperations(this WebApplication app)
    {
        app.MapMethods(Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.RestypeServiceCompProperties.ServiceSetProperties.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.RestypeServiceCompProperties.ServiceSetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.CompList.ServiceListSharesSegment.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.CompList.ServiceListSharesSegment.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShare.ShareGetProperties.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameRestypeShare.ShareGetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShare.ShareCreate.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShare.ShareCreate.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShare.ShareDelete.Operation.PathTemplate, ["DELETE"], Azure.Files.Emulator.ShareNameRestypeShare.ShareDelete.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompLeaseRelease.ShareReleaseLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompLeaseRelease.ShareReleaseLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompLeaseChange.ShareChangeLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompLeaseChange.ShareChangeLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompLeaseRenew.ShareRenewLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompLeaseRenew.ShareRenewLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompLeaseBreak.ShareBreakLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompLeaseBreak.ShareBreakLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompSnapshot.ShareCreateSnapshot.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompSnapshot.ShareCreateSnapshot.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareCreatePermission.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareCreatePermission.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompProperties.ShareSetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareSetAccessPolicy.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompStats.ShareGetStatistics.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameRestypeShareCompStats.ShareGetStatistics.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameRestypeShareCompUndelete.ShareRestore.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameRestypeShareCompUndelete.ShareRestore.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryGetProperties.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryGetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryCreate.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryCreate.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryDelete.Operation.PathTemplate, ["DELETE"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryDelete.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryCompListhandles.DirectoryListHandles.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryCompListhandles.DirectoryListHandles.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryCompForceclosehandles.DirectoryForceCloseHandles.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryCompForceclosehandles.DirectoryForceCloseHandles.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileName.FileCreate.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileName.FileCreate.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileName.FileDelete.Operation.PathTemplate, ["DELETE"], Azure.Files.Emulator.ShareNameDirectoryFileName.FileDelete.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileName.FileGetProperties.Operation.PathTemplate, ["HEAD"], Azure.Files.Emulator.ShareNameDirectoryFileName.FileGetProperties.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompMetadata.FileSetMetadata.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompMetadata.FileSetMetadata.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseRelease.FileReleaseLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseRelease.FileReleaseLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseChange.FileChangeLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseChange.FileChangeLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompRange.FileUploadRange.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompRange.FileUploadRange.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopy.FileStartCopy.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopy.FileStartCopy.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompForceclosehandles.FileForceCloseHandles.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompForceclosehandles.FileForceCloseHandles.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameCompRename.FileRename.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameCompRename.FileRename.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileGetSymbolicLink.Operation.PathTemplate, ["GET"], Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileGetSymbolicLink.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.Operation.HandleAsync);
        app.MapMethods(Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.Operation.PathTemplate, ["PUT"], Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink.Operation.HandleAsync);
        return app;
    }
}
#nullable restore


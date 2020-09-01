using System.ComponentModel;

namespace RenamerX
{
    public enum OperationType
    {
        Append,
        Prepend,
        Replace,
        InsertAt,
        [Description("Delete files less than specific resolution")]
        DeleteFilesLessThanResolution,
        [Description("Organize files by Date Modified")]
        OrganizeFilesDateCreated,
        [Description("Organize photos by Date Taken")]
        OrganizePhotos,
        [Description("Remove empty folders")]
        RemoveEmptyFolders
    }
}
using ShareX.HelpersLib;
using System.ComponentModel;
using System.Drawing.Design;

namespace RenamerX
{
    public class AppConfig : SettingsBase<AppConfig>
    {
        public OperationType OperationType { get; set; }

        public bool Files { get; set; }

        public bool Folders { get; set; }

        public WorkerConfig WorkerConfig { get; set; }

        public AppConfig()
        {
            WorkerConfig = new WorkerConfig();
        }
    }

    public class WorkerConfig
    {
        [Browsable(false)]
        public string FindText { get; set; }

        [Browsable(false)]
        public string ReplaceWithText { get; set; }

        [Category("Delete files less than specific resolution"), Description("Location of user specified Recycle Bin. Files in network shares are not moved to Windows Recycle Bin and therefore, it is recommended to specify your own folder to review files removed by this program.")]
        [Editor(typeof(DirectoryNameEditor), typeof(UITypeEditor))]
        public string RecycleBinPath { get; set; }

        [Category("Delete files less than specific resolution"), DefaultValue(512)]
        public int Width { get; set; }

        [Category("Delete files less than specific resolution"), DefaultValue(512)]
        public int Height { get; set; }

        [Category("Delete files less than specific resolution"), DefaultValue(100), Description("File size in KiB. Files less than this size will be removed.")]
        public int FileSize { get; set; }

        [Category("Organize photos")Description("Location of photos.")]
        [Editor(typeof(DirectoryNameEditor), typeof(UITypeEditor))]
        public string PhotosLocation { get; set; }

        public WorkerConfig()
        {
            this.ApplyDefaultPropertyValues();
        }
    }
}
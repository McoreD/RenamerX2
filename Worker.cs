using IndexerLib;
using Microsoft.VisualBasic.FileIO;
using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RenamerX
{
    internal static class Worker
    {
        public static List<FileInfo> Files { get; private set; }
        public static List<FolderInfo> Folders { get; private set; }

        public static event ProgressEventHandler ProgressChanged;

        private static readonly object progressLock = new object();

        public delegate void ProgressEventHandler(int current, int max);

        static Worker()
        {
            Files = new List<FileInfo>();
            Folders = new List<FolderInfo>();
        }

        private static void OnProgressChanged(int current, int max)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(current, max);
            }
        }

        public static void Load(string[] items)
        {
            foreach (string item in items)
            {
                if (File.Exists(item))
                {
                    Files.Add(new FileInfo(item));
                }
                else if (Directory.Exists(item))
                {
                    Folders.Add(new FolderInfo(item));
                }
            }
        }

        public static void Run(WorkerConfig config)
        {
            if (Program.Config.Files)
            {
                if (Files.Count == 0)
                {
                    Folders.ForEach(dir => Directory.GetFiles(dir.FolderPath, "*.*", System.IO.SearchOption.AllDirectories).ForEach(fi => Files.Add(new FileInfo(fi))));
                }

                int current = 0;
                int max = Files.Count();
                OnProgressChanged(current, max);

                Parallel.ForEach(Files, fi =>
                {
                    switch (Program.Config.OperationType)
                    {
                        case OperationType.Append:
                            File.Move(fi.FullName, Path.Combine(Path.GetDirectoryName(fi.FullName), Path.GetFileNameWithoutExtension(fi.FullName) + config.ReplaceWithText) + Path.GetExtension(fi.FullName));
                            break;

                        case OperationType.Prepend:
                            File.Move(fi.FullName, Path.Combine(Path.GetDirectoryName(fi.FullName), config.ReplaceWithText + Path.GetFileNameWithoutExtension(fi.FullName)) + Path.GetExtension(fi.FullName));
                            break;

                        case OperationType.Replace:
                            string fileNameNew = Regex.Replace(Path.GetFileName(fi.FullName), config.FindText, config.ReplaceWithText);
                            File.Move(fi.FullName, Path.Combine(Path.GetDirectoryName(fi.FullName), fileNameNew));
                            break;

                        case OperationType.DeleteFilesLessThanResolution:
                            DeleteByResolution(config, fi);
                            break;
                    }

                    lock (progressLock)
                    {
                        current++;
                        OnProgressChanged(current, max);
                    }
                });
            }

            if (Program.Config.Folders)
            {
                Parallel.ForEach(Folders, di =>
                {
                    switch (Program.Config.OperationType)
                    {
                        case OperationType.Append:
                            Directory.Move(di.FolderPath, di.FolderPath + config.ReplaceWithText);
                            break;

                        case OperationType.Prepend:
                            Directory.Move(di.FolderPath, config.ReplaceWithText + di.FolderPath);
                            break;

                        case OperationType.Replace:
                            string dirNameNew = Regex.Replace(di.FolderName, config.FindText, config.ReplaceWithText);
                            Directory.Move(di.FolderPath, Path.Combine(Path.GetDirectoryName(di.FolderPath), dirNameNew));
                            break;
                    }
                });
            }

            Clear();
        }

        private static void DeleteByResolution(WorkerConfig config, FileInfo fi)
        {
            if (Helpers.IsImageFile(fi.FullName) && config.Width > 0 && config.Height > 0)
            {
                using (Image img = ImageHelpers.LoadImage(fi.FullName))
                {
                    if (img != null && img.Width <= config.Width && img.Height <= config.Height)
                    {
                        if (string.IsNullOrEmpty(config.RecycleBinPath))
                            FileSystem.DeleteFile(fi.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        else
                            FileSystem.MoveFile(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(config.RecycleBinPath, Path.GetFileName(fi.FullName))));
                    }
                }
            }
        }

        public static void Clear()
        {
            Files.Clear();
            Folders.Clear();
        }
    }
}
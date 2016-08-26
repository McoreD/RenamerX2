using IndexerLib;
using Microsoft.VisualBasic.FileIO;
using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        public static List<FileInfo> FailedFiles { get; private set; }
        public static List<FolderInfo> Folders { get; private set; }

        public static event ProgressEventHandler ProgressChanged;

        private static readonly object progressLock = new object();

        public delegate void ProgressEventHandler(int current, int max);

        static Worker()
        {
            Files = new List<FileInfo>();
            FailedFiles = new List<FileInfo>();
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

        public static void Run(AppConfig config)
        {
            if (Program.Files)
            {
                ProcessFiles(config, Files);
            }

            if (FailedFiles.Count > 0)
                ProcessFiles(config, FailedFiles);

            if (Program.Folders)
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

                        case OperationType.RemoveEmptyFolders:
                            if (EmptyFolderHelper.CheckDirectoryEmpty(di.FolderPath))
                                Directory.Move(di.FolderPath, Path.Combine(config.RecycleBinPath, di.FolderName));
                            break;

                        default:
                            ProcessFiles(config);
                            break;
                    }
                });
            }

            Clear();
        }

        private static void ProcessFiles(AppConfig config, List<FileInfo> files = null)
        {
            if (files == null || files.Count == 0)
            {
                if (files == null) files = new List<FileInfo>();
                Folders.ForEach(dir => Directory.GetFiles(dir.FolderPath, "*.*", System.IO.SearchOption.AllDirectories).ForEach(fi => files.Add(new FileInfo(fi))));
            }

            int current = 0;
            int max = files.Count();
            OnProgressChanged(current, max);

            Parallel.ForEach(files, fi =>
            {
                switch (Program.Config.OperationType)
                {
                    case OperationType.Append:
                        File.Move(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(Path.GetDirectoryName(fi.FullName), Path.GetFileNameWithoutExtension(fi.FullName) + config.ReplaceWithText) + Path.GetExtension(fi.FullName)));
                        break;

                    case OperationType.Prepend:
                        File.Move(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(Path.GetDirectoryName(fi.FullName), config.ReplaceWithText + Path.GetFileNameWithoutExtension(fi.FullName)) + Path.GetExtension(fi.FullName)));
                        break;

                    case OperationType.InsertAt:
                        File.Move(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(Path.GetDirectoryName(fi.FullName), Path.GetFileNameWithoutExtension(fi.FullName).Insert(config.InsertAtIndex, config.ReplaceWithText)) + Path.GetExtension(fi.FullName)));
                        break;

                    case OperationType.Replace:
                        File.Move(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(Path.GetDirectoryName(fi.FullName), Regex.Replace(Path.GetFileName(fi.FullName), config.FindText, config.ReplaceWithText))));
                        break;

                    case OperationType.DeleteFilesLessThanResolution:
                        DeleteByResolution(config, fi);
                        break;

                    case OperationType.OrganizePhotos:
                        OrganizePhotos(config, fi);
                        break;
                }

                lock (progressLock)
                {
                    current++;
                    OnProgressChanged(current, max);
                }
            });
        }

        private static void DeleteByResolution(AppConfig config, FileInfo fi)
        {
            if (Helpers.IsImageFile(fi.FullName) && config.Width > 0 && config.Height > 0)
            {
                using (Image img = ImageHelpers.LoadImage(fi.FullName))
                {
                    if (img == null && fi.Length < config.FileSize * 1024 ||
                        img != null && img.Width <= config.Width && img.Height <= config.Height)
                    {
                        if (string.IsNullOrEmpty(config.RecycleBinPath))
                            FileSystem.DeleteFile(fi.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        else
                            FileSystem.MoveFile(fi.FullName, Helpers.GetUniqueFilePath(Path.Combine(config.RecycleBinPath, Path.GetFileName(fi.FullName))));
                    }
                    else if (img == null)
                    {
                        FailedFiles.Add(fi);
                    }
                }
            }
        }

        private static void OrganizePhotos(AppConfig config, FileInfo fi)
        {
            if (Helpers.IsImageFile(fi.FullName))
            {
                string desc = string.Empty;
                Match r = Regex.Match(Path.GetFileName(Path.GetDirectoryName(fi.FullName)), @"\d{4}-\d{2}-\d{2} (.+)");
                if (r.Success)
                    desc = r.Groups[1].Value;

                string dateTaken = GetDateTakenFromImage(fi.FullName).ToString("yyyy-MM-dd");
                if (File.Exists(fi.FullName))
                {
                    string dirName = !string.IsNullOrEmpty(desc) ? dateTaken + " " + desc : dateTaken;

                    string dest = Path.Combine(config.PhotosLocation, dirName, Path.GetFileName(fi.FullName));
                    if (!dest.Equals(fi.FullName))
                    {
                        FileSystem.MoveFile(fi.FullName, Helpers.GetUniqueFilePath(dest));
                    }
                }
            }
        }

        //retrieves the datetime without loading the whole image
        public static DateTime GetDateTakenFromImage(string fp)
        {
            string fn = Path.GetFileNameWithoutExtension(fp);
            try
            {
                using (FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read))
                using (Image img = Image.FromStream(fs, false, false))
                {
                    if (img.PropertyIdList.Any(x => x == 36867))
                    {
                        PropertyItem propItem = img.GetPropertyItem(36867);
                        Regex regex = new Regex(":");
                        string dateTaken = regex.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                        return DateTime.Parse(dateTaken);
                    }
                }
            }
            catch (Exception)
            {
                FileSystem.DeleteFile(fp, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }

            if (fn.StartsWith("CameraZOOM"))
            {
                Match r = Regex.Match(fn, @".+?-(?<y>\d{4})(?<m>\d{2})(?<d>\d{2}).+");
                if (r.Success)
                    return DateTime.Parse(r.Groups[1].Value + "-" + r.Groups[2].Value + "-" + r.Groups[3].Value);
            }

            DateTime dateModfied = File.GetLastWriteTime(fp);
            DateTime dateCreated = File.GetCreationTime(fp);

            return dateModfied < dateCreated ? dateModfied : dateCreated;
        }

        public static void Clear()
        {
            Files.Clear();
            FailedFiles.Clear();
            Folders.Clear();
        }
    }
}
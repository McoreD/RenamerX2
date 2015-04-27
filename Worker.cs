using IndexerLib;
using System;
using System.Collections.Generic;
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

        static Worker()
        {
            Files = new List<FileInfo>();
            Folders = new List<FolderInfo>();
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

        public static void Clear()
        {
            Files.Clear();
            Folders.Clear();
        }
    }

    internal class WorkerConfig
    {
        internal string FindText { get; set; }
        internal string ReplaceWithText { get; set; }
    }
}
using IndexerLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerX
{
    internal static class Worker
    {
        public static List<FileInfo> Files { get; private set; }

        public static List<FolderInfo> Folders { get; private set; }

        public static void Load(string[] items)
        {
            Files = new List<FileInfo>();
            Folders = new List<FolderInfo>();

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

        public static void Run(string inputText)
        {
            if (Program.Config.Files)
            {
                foreach (FileInfo filePath in Files)
                {
                }
            }

            if (Program.Config.Folders)
            {
                foreach (FolderInfo folder in Folders)
                {
                    switch (Program.Config.OperationType)
                    {
                        case OperationType.Append:
                            Directory.Move(folder.FolderPath, folder.FolderPath + inputText);
                            break;
                    }
                }
            }
        }
    }
}
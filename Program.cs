using System;
using System.IO;
using System.Windows.Forms;

namespace RenamerX
{
    internal static class Program
    {
        public static readonly string ApplicationName = Application.ProductName;
        public static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationName);
        private static readonly string AppConfigFilename = "AppConfig.json";
        public static AppConfig Config { get; private set; }

        public static bool Files { get; set; }
        public static bool Folders { get; set; }

        public static string ApplicationConfigFilePath
        {
            get
            {
                return Path.Combine(ConfigPath, AppConfigFilename);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config = AppConfig.Load(ApplicationConfigFilePath);
            Application.Run(new MainForm());
            Config.Save(ApplicationConfigFilePath);
        }
    }
}
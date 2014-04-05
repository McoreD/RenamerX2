using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenamerX
{
    static class Program
    {
        public static readonly string ApplicationName = Application.ProductName;
        public static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationName);
        private static readonly string AppConfigFilename = "AppConfig.json";
        public static AppConfig Config { get; private set; }

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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config = AppConfig.Load(AppConfigFilename);

            Application.Run(new MainForm());

            Config.Save(AppConfigFilename);
        }
    }
}

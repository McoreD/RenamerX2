using HelpersLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerX
{
    public class AppConfig : SettingsBase<AppConfig>
    {
        public OperationType OperationType { get; set; }

        public bool Files { get; set; }

        public bool Folders { get; set; }
    }
}
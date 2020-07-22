using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace MotorsportManagerHelper.src.Services.Helpers
{
    public static class DefaultSettings
    {
        public static string SaveDirectory { get {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SaveData");
            } }
    }
}

using System.IO;
using System.Reflection;

namespace MotorsportManagerHelper.src.Services.Helpers
{
    public static class DefaultSettings
    {
        private const string SAVE_DIR = "SaveData";
        private const string DATA_DIR = "Data";
        private const string MEDIA_DIR = "media";

        public static string SaveDirectory 
        { 
            get 
            {
                return DirectoryPath(SAVE_DIR);
            } 
        }

        public static string DataDirectory
        {
            get
            {
                return DirectoryPath(DATA_DIR);
            }
        }

        public static string MediaDirectory
        {
            get {
                return DirectoryPath(MEDIA_DIR);
            }
        }

        public static string AppDirectory
        {
            get {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        private static string DirectoryPath(string directory)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), directory);
        }
    }
}

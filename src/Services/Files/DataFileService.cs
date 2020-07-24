using Newtonsoft.Json;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MotorsportManagerHelper.src.Services.Files
{
    public class DataFileService<T> where T : new()
    {

        public DataFileService()
        {
        }

        public T GetData(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{filePath} does not exist");

            using (var fileReader = new StreamReader(filePath))
            {
                var fileContents = fileReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            
        }

        public string GetLastFileName(string directoryPath, string pattern)
        {
            var lastFile = GetLastFile(directoryPath, pattern);

            return lastFile.Name ?? "";
        }


        public T GetLastSavedData(string directoryPath, string pattern)
        {
            var lastFile = GetLastFile(directoryPath, pattern);

            return GetData(lastFile.FullName);

        }

        public void SaveData(string filePath, T data)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                throw new DirectoryNotFoundException("Invalid path");

            using (var fileReader = new StreamWriter(filePath))
            {
                fileReader.Write(JsonConvert.SerializeObject(data));
            }
        }

        public void CreateDataFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        private FileInfo GetLastFile(string directoryPath, string pattern)
        {
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"{directoryPath} not found");

            if (Directory.GetFiles(directoryPath).Count() == 0)
                return default;

            return new DirectoryInfo(directoryPath).GetFiles(pattern).OrderBy(x => x.LastWriteTime).First();
        }

    }
}

using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.src.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MotorsportManagerHelper.src.Services
{
    public class FileService : IFileService
    {
        private string _saveFilesPath;
        public string SaveFilesPath
        {
            get
            {
                if (!Directory.Exists(_saveFilesPath))
                    throw new DirectoryNotFoundException($"Path: {SaveFilesPath} does not exist");

                return _saveFilesPath;
            }
            set => _saveFilesPath = value;
        }


        public FileService(string filesPath)
        {
            SaveFilesPath = filesPath;
        }

        public string SaveSeason(Season season)
        {
            
            var fileName = $"{season.Id}_{DateTime.UtcNow.Millisecond}.save";
            var filePath = Path.Combine(SaveFilesPath, fileName);

            return SaveSeason(season, filePath);
        }

        public string SaveSeason(Season season, string filePath)
        {
            var serialized = JsonConvert.SerializeObject(season);

            using (var fileStream = new StreamWriter(filePath,false))
            {
                fileStream.Write(serialized);
            }

            return filePath;
        }

        public (string fileName, Season season) LoadLastSeason()
        {
            var lastFile = new DirectoryInfo(SaveFilesPath).GetFiles().OrderBy(x => x.LastWriteTime).First();
            return LoadSeason(lastFile.FullName);
        }

        public List<string> GetSaveFiles()
        {
            return Directory.GetFiles(SaveFilesPath, "*.save").ToList();
        }

        public (string fileName, Season season) LoadSeason(string saveFilePath)
        {
            Season returnSeason;

            if (!File.Exists(saveFilePath))
                throw new FileNotFoundException($"File {saveFilePath} does not exist");

            using (var fileReader = new StreamReader(saveFilePath))
            {
                returnSeason = JsonConvert.DeserializeObject<Season>(fileReader.ReadToEnd());
            }

            return (saveFilePath,returnSeason);
        }





    }
}

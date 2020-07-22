using MotorsportManagerHelper.src.Models;
using System.Collections.Generic;

namespace MotorsportManagerHelper.src.Services.Interfaces
{
    public interface IFileService
    {
        string SaveFilesPath { get; set; }

        List<string> GetSaveFiles();
        (string fileName, Season season) LoadLastSeason();
        (string fileName, Season season) LoadSeason(string saveFilePath);
        string SaveSeason(Season season);
        string SaveSeason(Season season, string filePath);
    }
}   
using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.src.Services.Files;
using MotorsportManagerHelper.src.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Animation;

namespace MotorsportManagerHelper.src.Services
{
    public class DataService
    {
        private const string RACE_PREFIX = "race_";
        private const string RACE_PATTERN = "race_*";
        private const string TYRE_PATTERN = "Tyres*";

        private DataFileService _dataFileService;

        public DataService()
        {
            _dataFileService = new DataFileService();
            CheckDataDirectory();
        }

        private void CheckDataDirectory()
        {
            try
            {
                _dataFileService.CreateDataFolder(DefaultSettings.DataDirectory);
            }
            catch (Exception)
            {
                Debug.Print("Can't create data directory");
            }
        }

        public List<Track> GetLatestRaceData()
        {
            try
            {
                return _dataFileService.GetLastSavedData<List<Track>>(DefaultSettings.DataDirectory, RACE_PATTERN);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Tyre> GetTyreData()
        {
           return _dataFileService.GetLastSavedData<List<Tyre>>(DefaultSettings.DataDirectory, TYRE_PATTERN);
        }

        public void SaveRaces(List<Track> tracks, bool newfile = false)
        {
            string fileName = "";
            CheckRaceIds(ref tracks);

            if (!newfile)
            {
                fileName = _dataFileService.GetLastFileName(DefaultSettings.DataDirectory, RACE_PATTERN);
            }

            if (string.IsNullOrEmpty(fileName) || newfile)
            { 
                fileName = $"{RACE_PREFIX}{Guid.NewGuid()}.data";
            }
            
            var filePath = Path.Combine(DefaultSettings.DataDirectory, fileName);
            _dataFileService.SaveData(filePath, tracks);

        }

        private void CheckRaceIds(ref List<Track> tracks)
        {
            foreach (var track in tracks)
            {
                if (track.Id == Guid.Empty)
                {
                    track.Id = Guid.NewGuid();
                }
            }
        }
    }
}

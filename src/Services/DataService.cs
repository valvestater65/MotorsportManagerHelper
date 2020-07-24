﻿using MotorsportManagerHelper.src.Models;
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

        private DataFileService<List<Track>> _raceDataFiles;

        public DataService()
        {
            _raceDataFiles = new DataFileService<List<Track>>();
            CheckDataDirectory();
        }

        private void CheckDataDirectory()
        {
            try
            {
                _raceDataFiles.CreateDataFolder(DefaultSettings.DataDirectory);
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
                return _raceDataFiles.GetLastSavedData(DefaultSettings.DataDirectory, RACE_PATTERN);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SaveRaces(List<Track> tracks, bool newfile = false)
        {
            string fileName = "";
            CheckRaceIds(ref tracks);

            if (!newfile)
            {
                fileName = _raceDataFiles.GetLastFileName(DefaultSettings.DataDirectory, RACE_PATTERN);
            }

            if (string.IsNullOrEmpty(fileName) || newfile)
            { 
                fileName = $"{RACE_PREFIX}{Guid.NewGuid()}.data";
            }
            
            var filePath = Path.Combine(DefaultSettings.DataDirectory, fileName);
            _raceDataFiles.SaveData(filePath, tracks);

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

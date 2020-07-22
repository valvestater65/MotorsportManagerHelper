using MahApps.Metro.Converters;
using MotorsportManagerHelper.src.Services.Interfaces;
using MotorsportManagerHelper.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorsportManagerHelper.src.Services
{
    public class SeasonManagerService
    {
        private Season _currentSeason;
        private string _currentSavePath;
        private string _seasonFileName; 
        IFileService _fileService;

        public SeasonManagerService(string currentSavePath)
        {
            _currentSavePath = currentSavePath;
            _fileService = new FileService(currentSavePath);
        }

        public Season CurrentSeason {
            get {
                if (_currentSeason == null)
                    return new Season();
                return _currentSeason;
            }

            private set => _currentSeason = value; 
        }

        public List<Race> GetSeasonRaces()
        {
            return _currentSeason.Races?.ToList(); 
        }

        public Season LoadSeason(bool last, string filePath = "")
        {
            if (last)
            {
                var loadedSeason = _fileService.LoadLastSeason();
                
                CurrentSeason = loadedSeason.season;
                _seasonFileName = loadedSeason.fileName;

                return CurrentSeason;
            }

            if (!string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Can't be empty", "filePath");

            var loadSeason = _fileService.LoadSeason(filePath);
            CurrentSeason = loadSeason.season;
            _seasonFileName = loadSeason.fileName;

            return CurrentSeason;

        }

        public void SaveSeason()
        {
            if (string.IsNullOrEmpty(_seasonFileName))
            {
                _fileService.SaveSeason(CurrentSeason, _seasonFileName);
            }
            else {

                _seasonFileName = _fileService.SaveSeason(CurrentSeason);
            }
        }
    }
}

using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.src.Services;
using MotorsportManagerHelper.src.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace MotorsportManagerHelper.src.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        private Season currentSeason;
        private ObservableCollection<string> categoryTypes;
        private ObservableCollection<Track> availableTracks;
        private Track currentSelectedTrack;
        private bool _loadLastSessionVisible;
        private ApplicationService _currentSession;

        private ParameterLessCommand addSeasonRace;
        private ParameterLessCommand _loadLastSession;
        private ParameterLessCommand _hidePops;
        private ParameterLessCommand _saveSession;


        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<string> CategoryTypes { get => categoryTypes; set { categoryTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<Track> AvailableTracks { get => availableTracks; set { availableTracks = value; OnPropertyChanged(); } }
        public Track CurrentSelectedTrack { get => currentSelectedTrack; set { currentSelectedTrack = value; OnPropertyChanged(); } }
        public ParameterLessCommand AddSeasonRace { get => addSeasonRace; set { addSeasonRace = value; OnPropertyChanged(); } }
        public bool LoadLastSessionVisible { get => _loadLastSessionVisible; set { _loadLastSessionVisible = value; OnPropertyChanged(); } }
        public ParameterLessCommand LoadLastSession { get => _loadLastSession; set { _loadLastSession = value; OnPropertyChanged(); } }
        public ParameterLessCommand HidePops { get => _hidePops; set { _hidePops = value; OnPropertyChanged(); } }
        public ParameterLessCommand SaveCurrentSeason { get => _saveSession; set { _saveSession = value; OnPropertyChanged(); } }

        public SeasonViewModel()
        {
            _currentSession = ApplicationService.Instance;
            LoadLastSession = new ParameterLessCommand(LoadLastSavedSession);
            HidePops = new ParameterLessCommand(ClosePopup);
            SaveCurrentSeason = new ParameterLessCommand(SaveSeason);
            InitializeCategories();
            InitializeRaces();
            SetCommands();
            CheckLoadedSeason();
        }

        private void SetCommands()
        {
            AddSeasonRace = new ParameterLessCommand(AddRaceToSeason);
        }


        private void CheckLoadedSeason()
        {
            if (_currentSession.SeasonManager.CurrentSeason != null)
            {
                CurrentSeason = _currentSession.SeasonManager.CurrentSeason;
                LoadLastSessionVisible = false;
            }
            else {
                
                if (!_currentSession.SeasonManager.PreviousSeasonExists())
                {
                    CurrentSeason = new Season();
                    LoadLastSessionVisible = false;
                }
                else
                {
                    LoadLastSessionVisible = true;
                }
            }

        }

        private void LoadLastSavedSession()
        {
            CurrentSeason = _currentSession.SeasonManager.LoadSeason(true);
            LoadLastSessionVisible = false;
        }

        private void ClosePopup()
        {
            LoadLastSessionVisible = false;
        }


        private void InitializeCategories()
        {
            CategoryTypes = new ObservableCollection<string> {
                "Challenger GT",
                "International GT",
                "Endurance",
                "Formula",
                "Formula World Champ"
            };
        }

        private void InitializeRaces()
        {
            AvailableTracks = new ObservableCollection<Track>
            {
                new Track{
                    Id = Guid.NewGuid(),
                    Name = "Montmeló",
                    Layout  = "A"
                },
                new Track{
                    Id = Guid.NewGuid(),
                    Name = "Montmeló",
                    Layout  = "B"
                },
                new Track{
                    Id = Guid.NewGuid(),
                    Name = "Spa",
                    Layout  = "A"
                },
                new Track{
                    Id = Guid.NewGuid(),
                    Name = "Spa",
                    Layout  = "B"
                }
            };
        }

        private void AddRaceToSeason()
        {
            var race = new Race {
                Id = Guid.NewGuid(),
                Name = $"{CurrentSelectedTrack.Name} - {CurrentSelectedTrack.Layout}",
                Track = CurrentSelectedTrack,
                RaceDate = DateTime.UtcNow
            };

            CurrentSeason.Races.Add(race);

        }

        private void SaveSeason()
        {
            if (_currentSession.SeasonManager.CurrentSeason == null)
            {
                _currentSession.SeasonManager.CurrentSeason = CurrentSeason;
            }

            _currentSession.SeasonManager.SaveSeason();
        }

    }
}

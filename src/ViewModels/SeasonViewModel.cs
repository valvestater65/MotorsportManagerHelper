using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.src.Services;
using MotorsportManagerHelper.src.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;

namespace MotorsportManagerHelper.src.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        private Season currentSeason;
        private ObservableCollection<string> categoryTypes;
        private ObservableCollection<Track> availableTracks;
        private ObservableCollection<Race> dataRaces;
        private Track currentSelectedTrack;
        private Track _newAddedTrack;
        private bool _loadLastSessionVisible;
        private bool _showRaceEditor;
        private ApplicationService _currentSession;
        private DataService _currentDataService; 
        private Race _newAddedRace;

        private ParameterLessCommand addSeasonRace;
        private ParameterLessCommand _loadLastSession;
        private ParameterLessCommand _hidePops;
        private ParameterLessCommand _saveSession;
        private ParameterLessCommand _addNewTrack;
        private ParameterLessCommand _showTrackEditor;
        private ParameterLessCommand _saveTracks;


        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<string> CategoryTypes { get => categoryTypes; set { categoryTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<Track> AvailableTracks { get => availableTracks; set { availableTracks = value; OnPropertyChanged(); } }
        public ObservableCollection<Race> DataRaces { get => dataRaces; set { dataRaces = value; OnPropertyChanged(); } }
        public Track CurrentSelectedTrack { get => currentSelectedTrack; set { currentSelectedTrack = value; OnPropertyChanged(); } }
        public Race NewAddedRace { get => _newAddedRace; set { _newAddedRace = value; OnPropertyChanged(); } }
        public bool IsTrackEditorOpen { get => _showRaceEditor; set { _showRaceEditor = value; OnPropertyChanged(); } }
        public Track NewAddedTrack { get => _newAddedTrack; set { _newAddedTrack = value; OnPropertyChanged(); } }
        
        public ParameterLessCommand AddSeasonRace { get => addSeasonRace; set { addSeasonRace = value; OnPropertyChanged(); } }
        public bool LoadLastSessionVisible { get => _loadLastSessionVisible; set { _loadLastSessionVisible = value; OnPropertyChanged(); } }
        public ParameterLessCommand LoadLastSession { get => _loadLastSession; set { _loadLastSession = value; OnPropertyChanged(); } }
        public ParameterLessCommand HidePops { get => _hidePops; set { _hidePops = value; OnPropertyChanged(); } }
        public ParameterLessCommand SaveCurrentSeason { get => _saveSession; set { _saveSession = value; OnPropertyChanged(); } }
        public ParameterLessCommand AddNewTrack { get => _addNewTrack; set { _addNewTrack = value; OnPropertyChanged(); } }
        public ParameterLessCommand ShowTrackEditor { get => _showTrackEditor; set { _showTrackEditor = value; OnPropertyChanged(); } }
        public ParameterLessCommand SaveTracks { get => _saveTracks; set { _saveTracks = value; OnPropertyChanged(); } }

        public SeasonViewModel()
        {
            _currentSession = ApplicationService.Instance;
            _currentDataService = _currentSession.FixedDataService;
            _newAddedTrack = new Track();
            AvailableTracks = new ObservableCollection<Track>();
            IsTrackEditorOpen = false;
            InitializeCategories();
            InitializeRaces();
            SetCommands();
            CheckLoadedSeason();
        }

        private void SetCommands()
        {
            AddSeasonRace = new ParameterLessCommand(AddRaceToSeason);
            LoadLastSession = new ParameterLessCommand(LoadLastSavedSession);
            HidePops = new ParameterLessCommand(ClosePopup);
            SaveCurrentSeason = new ParameterLessCommand(SaveSeason);
            AddNewTrack = new ParameterLessCommand(CreateNewTrack);
            ShowTrackEditor = new ParameterLessCommand(OpenTrackEditor);
            SaveTracks = new ParameterLessCommand(SaveTrackList);
        }


        private void SaveTrackList()
        {
            _currentDataService.SaveRaces(AvailableTracks.ToList());
        }


        private void CreateNewTrack()
        {
            if (!string.IsNullOrEmpty(_newAddedTrack.Name))
            {
                AvailableTracks.Add(new Track
                    { 
                        Name = _newAddedTrack.Name,
                        Layout = _newAddedTrack.Layout
                    }
                );
            }
            IsTrackEditorOpen = false;
            NewAddedTrack = new Track();

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
            CurrentSeason = new Season();
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

            var trackList =  _currentDataService.GetLatestRaceData();

            if (trackList != null)
            {
                AvailableTracks = new ObservableCollection<Track>();

                foreach (var track in trackList)
                {
                    AvailableTracks.Add(new Track { 
                        Name = track.Name,
                        Layout = track.Layout
                    }
                    );
                }
            }

            //AvailableTracks = new ObservableCollection<Track>
            //{
            //    new Track{
            //        Id = Guid.NewGuid(),
            //        Name = "Montmeló",
            //        Layout  = "A"
            //    },
            //    new Track{
            //        Id = Guid.NewGuid(),
            //        Name = "Montmeló",
            //        Layout  = "B"
            //    },
            //    new Track{
            //        Id = Guid.NewGuid(),
            //        Name = "Spa",
            //        Layout  = "A"
            //    },
            //    new Track{
            //        Id = Guid.NewGuid(),
            //        Name = "Spa",
            //        Layout  = "B"
            //    }
            //};
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

        private void OpenTrackEditor()
        {
            IsTrackEditorOpen = true;
        }

        private void SaveRace()
        { 

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

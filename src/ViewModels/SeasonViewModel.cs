using MotorsportManagerHelper.src.Models;
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
        private ParameterLessCommand addSeasonRace;

        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<string> CategoryTypes { get => categoryTypes; set { categoryTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<Track> AvailableTracks { get => availableTracks; set { availableTracks = value; OnPropertyChanged(); } }
        public Track CurrentSelectedTrack { get => currentSelectedTrack; set { currentSelectedTrack = value; OnPropertyChanged(); } }
        public ParameterLessCommand AddSeasonRace { get => addSeasonRace; set { addSeasonRace = value; OnPropertyChanged(); } }

        public SeasonViewModel()
        {
            CurrentSeason = new Season();
            InitializeCategories();
            InitializeRaces();
            SetCommands();
        }

        public SeasonViewModel(Season currentSeason):this()
        {
            CurrentSeason = currentSeason;
        }

        private void SetCommands()
        {
            AddSeasonRace = new ParameterLessCommand(AddRaceToSeason);
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

    }
}

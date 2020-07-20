using MotorsportManagerHelper.src.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotorsportManagerHelper.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        private Season currentSeason;
        private ObservableCollection<string> categoryTypes;
        private ObservableCollection<Track> availableTracks;

        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<string> CategoryTypes { get => categoryTypes; set { categoryTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<Track> AvailableTracks { get => availableTracks; set { availableTracks = value; OnPropertyChanged(); } }

        public SeasonViewModel()
        {
            CurrentSeason = new Season();
            InitializeCategories();
            InitializeRaces();
        }

        public SeasonViewModel(Season currentSeason)
        {
            CurrentSeason = currentSeason;
            InitializeCategories();
            InitializeRaces();
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


    }
}

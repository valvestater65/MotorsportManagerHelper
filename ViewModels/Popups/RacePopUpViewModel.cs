using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MotorsportManagerHelper.ViewModels.Popups
{
    public class RacePopUpViewModel : BaseViewModel
    {
        private Race currentRace;
        private Season currentSeason;
        private ObservableCollection<Race> existingRaces;
        private RelayCommand<Race> selectCurrentRace;
        private ParameterLessCommand removeRace;
        private ParameterLessCommand createRace;
        private ParameterLessCommand changeRace;

        public Race CurrentRace { get => currentRace; set { currentRace = value; OnPropertyChanged(); } }
        public ObservableCollection<Race> ExistingRaces { get => existingRaces; set { existingRaces = value; OnPropertyChanged(); } }
        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public RelayCommand<Race> SelectCurrentRace { get => selectCurrentRace; set { selectCurrentRace = value; OnPropertyChanged(); } }
        public ParameterLessCommand DeleteRace { get => removeRace; set { removeRace = value; OnPropertyChanged(); } }
        public ParameterLessCommand CreateRace { get => createRace; set { createRace = value; OnPropertyChanged(); } }
        public ParameterLessCommand ChangeRace { get => changeRace; set { changeRace = value; OnPropertyChanged(); } }

        public RacePopUpViewModel(Season currentSeason)
        {
            CurrentSeason = currentSeason;
            SelectCurrentRace = new RelayCommand<Race>(SetCurrentRace);
            DeleteRace = new ParameterLessCommand(RemoveRace);
            CreateRace = new ParameterLessCommand(AddNewRace);
            ChangeRace = new ParameterLessCommand(UpdateRace);
        }

        private void InitializeExistingRaces()
        {
            ExistingRaces = new ObservableCollection<Race>
            {
                new Race{
                    Track = new Track{
                        Id = Guid.NewGuid(),
                        Layout = "A",
                        Name = "Spa"
                    },
                    RaceDate = DateTime.UtcNow
                },
                new Race{
                    Track = new Track{
                        Id = Guid.NewGuid(),
                        Layout = "A",
                        Name = "Montmeló"
                    },
                    RaceDate = DateTime.UtcNow
                },
                new Race{
                    Track = new Track{
                        Id = Guid.NewGuid(),
                        Layout = "B",
                        Name = "Spa"
                    },
                    RaceDate = DateTime.UtcNow
                },
                new Race{
                    Track = new Track{
                        Id = Guid.NewGuid(),
                        Layout = "B",
                        Name = "Montmeló"
                    },
                    RaceDate = DateTime.UtcNow
                }

            };
        }
        private void SetCurrentRace(Race race)
        {
            CurrentRace = race; 
        }

        private void AddNewRace()
        {
            ExistingRaces.Add(CurrentRace);
        }

        private void RemoveRace()
        {
            ExistingRaces.Remove(ExistingRaces.Where(x => x.Id == currentRace.Id).FirstOrDefault());
        }

        private void UpdateRace()
        {
            RemoveRace();
            AddNewRace();
        }


    }
}

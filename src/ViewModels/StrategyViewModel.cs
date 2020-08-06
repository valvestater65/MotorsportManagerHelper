using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.src.Services;
using MotorsportManagerHelper.src.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace MotorsportManagerHelper.src.ViewModels
{
    public class StrategyViewModel : BaseViewModel
    {
        private Season currentSeason;
        private ObservableCollection<DriverStints> calculatedStints;
        private Session raceSession;
        private ObservableCollection<Compound> sessionCompounds;
        private ApplicationService sessionMgr;
        private DataService _fixDataService;
        private StrategyService _strategyService;
        private Race _currentRace;

        private ParameterLessCommand _getBack;
        private ParameterLessCommand _getCalculatedStints;

        public ObservableCollection<DriverStints> CalculatedStints { get => calculatedStints; set { calculatedStints = value; OnPropertyChanged(); } }
        public Session RaceSession { get => raceSession; set { raceSession = value; OnPropertyChanged(); } }
        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<Compound> SessionCompounds { get => sessionCompounds; set { sessionCompounds = value; OnPropertyChanged(); } }
        public ParameterLessCommand GetBack { get => _getBack; set { _getBack = value; OnPropertyChanged(); } }
        public Race CurrentRace { get => _currentRace; set { _currentRace = value; OnPropertyChanged(); } }
        public ParameterLessCommand GetCalculatedStints { get => _getCalculatedStints; set { _getCalculatedStints = value; OnPropertyChanged(); } }

        public StrategyViewModel()
        {
            CalculatedStints = new ObservableCollection<DriverStints>();
            SessionCompounds = new ObservableCollection<Compound>();
            RaceSession = new Session();
            sessionMgr = ApplicationService.Instance;
            _fixDataService = sessionMgr.FixedDataService;
            GetBack = new ParameterLessCommand(GoBack);
            GetCalculatedStints = new ParameterLessCommand(GenerateStints);
            InitializeDemoData();
            ValidateSeasonLoaded();

        }

        private void GoBack()
        {
            sessionMgr.Navigation.GoBack();
        }

        private void ValidateSeasonLoaded()
        {
            if (sessionMgr.SeasonManager.CurrentSeason == null)
            {
                //No season loaded require user to load one. 
            }
            else
            {
                CurrentSeason = sessionMgr.SeasonManager.CurrentSeason;
            }
        }


        private void InitializeDemoData()
        {
            CalculatedStints.Add(new DriverStints { 
                Driver = new Driver { 
                    Id = Guid.NewGuid(),
                    Name = "TestDriver"
                },
                Stints = new ObservableCollection<Stint> { 
                    new Stint{ 
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound { 
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\Hard.png"
                        }
                    },
                    new Stint{
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound {
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\SuperSoft.png"
                        }
                    },
                    new Stint{
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound {
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\Soft.png"
                        }
                    }
                }
            });


            CalculatedStints.Add(new DriverStints
            {
                Driver = new Driver
                {
                    Id = Guid.NewGuid(),
                    Name = "TestDriver 2"
                },
                Stints = new ObservableCollection<Stint> {
                    new Stint{
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound {
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\Hard.png"
                        }
                    },
                    new Stint{
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound {
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\SuperSoft.png"
                        }
                    },
                    new Stint{
                        Laps = 10,
                        Fuel = 10,
                        Tyre = new Compound {
                            MaxLaps = 10,
                            Thumbnail = @"C:\Users\valve\source\repos\MotorsportManagerHelper\media\Soft.png"
                        }
                    }
                }
            });
        }

        public void GenerateStints()
        {
            if (CurrentRace != null)
            {
                if (_strategyService == null)
                {
                    _strategyService = new StrategyService(CurrentSeason, CurrentRace);
                }

                _strategyService.CalculateRaceStints();
                CalculatedStints = _strategyService.CurrentStints;

            }
           
        }
    }
}

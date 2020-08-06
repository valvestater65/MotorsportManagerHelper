using MotorsportManagerHelper.src.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MotorsportManagerHelper.src.Services
{
    public class StrategyService
    {

        private readonly Season _currentSeason;
        private readonly Race _currentRace;
        private Session _currentSession;

        public ObservableCollection<DriverStints> CurrentStints { get; set; }


        public StrategyService(Season season, Race race)
        {
            _currentSeason = season;
            _currentRace = race;
            CurrentStints = new ObservableCollection<DriverStints>();
        }



        public void AddStint(Driver driver, Stint stint)
        { 
            
        }

        public void CalculateRaceStints()
        {
            foreach (var driver in _currentSeason.Drivers)
            {
                var driverStints = new DriverStints();
                driverStints.Driver = driver;

                

                //Usually compounds with less Max Laps are the fastest. 
                //Assumption is one stint per compound. 
                //We try to generate stints with the fastest compounds possible. 
                var remainingLaps = _currentRace.RaceLaps;
                foreach (var tyreSet in _currentRace.Compounds.OrderBy(x => x.MaxLaps))
                {
                    if (remainingLaps == 0)
                        break;

                    var newStint = new Stint
                    {
                        Tyre = tyreSet,
                        Laps = tyreSet.MaxLaps,
                        Id = Guid.NewGuid(),
                        Fuel = _currentSession.FuelPerLap * tyreSet.MaxLaps
                    };

                    remainingLaps -= tyreSet.MaxLaps;
                    driverStints.Stints.Add(newStint);
                }

                CurrentStints.Add(driverStints);
            }
        }


        private void CreateRaceSession()
        {
            if (_currentRace != null)
            {
                _currentSession = new Session
                {
                    Name = "Race",
                    Laps = _currentRace.RaceLaps
                };

            }
        }

    }
}

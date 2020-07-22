using MotorsportManagerHelper.src.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MotorsportManagerHelper.src.ViewModels
{
    public class StrategyViewModel : BaseViewModel
    {
        private Season currentSeason;
        private ObservableCollection<DriverStints> calculatedStints;
        private Session raceSession;
        private ObservableCollection<Compound> sessionCompounds;

        public ObservableCollection<DriverStints> CalculatedStints { get => calculatedStints; set { calculatedStints = value; OnPropertyChanged(); } }
        public Session RaceSession { get => raceSession; set { raceSession = value; OnPropertyChanged(); } }
        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
        public ObservableCollection<Compound> SessionCompounds { get => sessionCompounds; set { sessionCompounds = value; OnPropertyChanged(); } }


        public StrategyViewModel()
        {
            CalculatedStints = new ObservableCollection<DriverStints>();
            SessionCompounds = new ObservableCollection<Compound>();
            RaceSession = new Session();
            InitializeDemoData();

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
            
            foreach (var driver in currentSeason.Drivers)
            {
                var driverStints = new DriverStints();
                driverStints.Driver = driver;
                //Usually compounds with less Max Laps are the fastest. 
                //Assumption is one stint per compound. 
                //We try to generate stints with the fastest compounds possible. 
                var remainingLaps = raceSession.Laps;
                foreach (var tyreSet in SessionCompounds.OrderBy(x => x.MaxLaps))
                {
                    if (remainingLaps == 0)
                        break;

                    var newStint = new Stint
                    {
                        Tyre = tyreSet,
                        Laps = tyreSet.MaxLaps,
                        Id = Guid.NewGuid(),
                        Fuel = RaceSession.FuelPerLap * tyreSet.MaxLaps
                    };

                    remainingLaps -= tyreSet.MaxLaps;
                    driverStints.Stints.Add(newStint);
                }

                CalculatedStints.Add(driverStints);
            }
        }

        //public void AddStint(Stint newStint)
        //{
        //    try
        //    {
        //        if (CalculatedStints != null)
        //        {
        //            CalculatedStints.Add(newStint);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Print($"Create Stint failed: {ex.Message}");
        //        throw;
        //    }
        //}

        //public void CreateStint()
        //{
        //    try
        //    {
        //        if (CalculatedStints != null)
        //        {
        //            CalculatedStints.Add(new Stint());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Print($"Add Stint failed: {ex.Message}");
        //        throw;
        //    }
        //}
        //public bool RemoveStint(Guid stintId)
        //{
        //    try
        //    {
        //        if (CalculatedStints != null)
        //        {
        //            return CalculatedStints.Remove(CalculatedStints.Where(x => x.Id == stintId).FirstOrDefault());
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Print($"RemoveStint Failed: {ex.Message}");
        //        return false;
        //    }
        //}



    }
}

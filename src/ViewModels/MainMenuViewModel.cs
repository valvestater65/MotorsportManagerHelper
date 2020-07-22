using MotorsportManagerHelper.src.Services;
using MotorsportManagerHelper.src.Models;
using MotorsportManagerHelper.UI;
using MotorsportManagerHelper.src.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace MotorsportManagerHelper.src.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private NavigationService navigation;
        private RelayCommand<Season> openStrategy;
        private RelayCommand<Season> openSeason;
        
        public RelayCommand<Season> OpenStrategy { get => openStrategy; set { openStrategy = value; OnPropertyChanged(); } }
        public RelayCommand<Season> OpenSeason { get => openSeason; set { openSeason = value; OnPropertyChanged(); } }

        public MainMenuViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
            OpenStrategy = new RelayCommand<Season>(OpenStrategyScreen);
            OpenSeason = new RelayCommand<Season>(OpenSeasonScreen);
        }


        private void OpenStrategyScreen(Season currentSeason)
        {
            var strategyVm = new StrategyViewModel();
            strategyVm.CurrentSeason = currentSeason;
            navigation.CurrentFrame.Navigate(new StrategyPage(strategyVm));
        }

        private void OpenSeasonScreen(Season currentSeason)
        {
            var seasonConfVM = new SeasonViewModel();
            navigation.CurrentFrame.Navigate(new SeasonConfigurationPage(seasonConfVM));
        }


    }
}

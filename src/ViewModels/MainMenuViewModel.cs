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
        private ApplicationService sessionManager;
        private ParameterLessCommand openStrategy;
        private ParameterLessCommand openSeason;
        
        public ParameterLessCommand OpenStrategy { get => openStrategy; set { openStrategy = value; OnPropertyChanged(); } }
        public ParameterLessCommand OpenSeason { get => openSeason; set { openSeason = value; OnPropertyChanged(); } }

        public MainMenuViewModel(ApplicationService sessionManager)
        {
            this.sessionManager = sessionManager;
            this.navigation = sessionManager.Navigation;
            OpenStrategy = new ParameterLessCommand(OpenStrategyScreen);
            OpenSeason = new ParameterLessCommand(OpenSeasonScreen);
        }


        private void OpenStrategyScreen()
        {
            var strategyVm = new StrategyViewModel();
            navigation.CurrentFrame.Navigate(new StrategyPage(strategyVm));
        }

        private void OpenSeasonScreen()
        {
            var seasonConfVM = new SeasonViewModel();
            navigation.CurrentFrame.Navigate(new SeasonConfigurationPage(seasonConfVM));
        }


    }
}

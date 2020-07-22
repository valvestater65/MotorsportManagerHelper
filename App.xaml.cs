using MotorsportManagerHelper.src.Services;
using MotorsportManagerHelper.UI;
using MotorsportManagerHelper.src.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;



namespace MotorsportManagerHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ApplicationService applicationService = ApplicationService.Instance;
        public static NavigationService navigation;
        public static SeasonManagerService seasonManager;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            navigation = new NavigationService(mainWindow.mainAppFrame);
            MainMenuViewModel mmVm = new MainMenuViewModel(navigation);

            applicationService.Navigation = navigation;
            applicationService.SeasonManager = seasonManager;

            mainWindow.mainAppFrame.Navigate(new MainMenuPage(mmVm));

        }
    }
   
}

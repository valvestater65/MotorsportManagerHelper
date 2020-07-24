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
using MotorsportManagerHelper.src.Services.Helpers;

namespace MotorsportManagerHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ApplicationService applicationService = ApplicationService.Instance;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            applicationService.Navigation = new NavigationService(mainWindow.mainAppFrame);
            applicationService.SeasonManager = new SeasonManagerService(DefaultSettings.SaveDirectory);
            applicationService.FixedDataService = new DataService();

            MainMenuViewModel mmVm = new MainMenuViewModel(applicationService);
            mainWindow.mainAppFrame.Navigate(new MainMenuPage(mmVm));

        }
    }
   
}

using MotorsportManagerHelper.src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        private Season currentSeason;
        
        public Season CurrentSeason { get => currentSeason; set { currentSeason = value; OnPropertyChanged(); } }
    }
}

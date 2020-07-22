using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Services
{
    public sealed class ApplicationService
    {
        private static ApplicationService instance;
        private static readonly object deadlock = new object();
        public NavigationService Navigation { get; set; }
        public SeasonManagerService SeasonManager { get; set; }


        public ApplicationService()
        {

        }

        public static ApplicationService Instance
        {
            get {
                lock (deadlock)
                if (instance == null)
                    return new ApplicationService();
                return instance;
            }
        }


    }
}

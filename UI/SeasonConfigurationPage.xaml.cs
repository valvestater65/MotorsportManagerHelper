using MahApps.Metro.Controls;
using MotorsportManagerHelper.src.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotorsportManagerHelper.UI
{
    /// <summary>
    /// Interaction logic for SeasonConfigurationPage.xaml
    /// </summary>
    public partial class SeasonConfigurationPage : Page
    {
        public SeasonConfigurationPage(SeasonViewModel currentSeason)
        {
            InitializeComponent();
            DataContext = currentSeason;
            this.Loaded += SeasonConfigurationPage_Loaded;
        }

        private void SeasonConfigurationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow(this);
            /*Just by changing the offset a little bit will cause repainting the popup within the window boundaries*/

            if (w != null)
            {
                w.LocationChanged += (object sender, EventArgs args) =>
                {
                    
                    var pops = this.GetChildObjects().First().GetChildObjects().Where(x => x.GetType() == typeof(Popup)).Select(x => (Popup)x).Where(x=> x.IsOpen);

                    foreach (var pop in pops)
                    {
                        var realpop = (Popup)pop;
                        var offset = realpop.HorizontalOffset;
                        realpop.HorizontalOffset = offset + 1;
                        realpop.HorizontalOffset = offset;

                    }
                };
            }

        }
    }
}

using MotorsportManagerHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for StrategyPage.xaml
    /// </summary>
    public partial class StrategyPage : Page
    {
        private readonly StrategyViewModel viewModel;
        public StrategyPage(StrategyViewModel viewModel)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}

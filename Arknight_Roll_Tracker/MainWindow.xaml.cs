using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arknight_Roll_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CurrentRoll Rollstreak = new CurrentRoll();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CurrentRoll();
        }

        private void Run_Pity_Calculator_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}

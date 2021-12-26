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

namespace WpfTask6
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void But1_Click(object sender, RoutedEventArgs e)
        {

            if (textBox != null)
            {
                textBox.Text = string.Empty;
                WeatherControl weatherSummary = new WeatherControl(30);
                weatherSummary.Modulation();
                foreach (string dayInfo in weatherSummary.daysSummary)
                {
                    textBox.Text += dayInfo + "\n\n";
                }
            }
        }
    }
}

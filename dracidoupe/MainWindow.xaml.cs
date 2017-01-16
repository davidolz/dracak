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

namespace dracidoupe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        newgame newgame;
        loadgame loadgame;       
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            newgame = new newgame();
            newgame.Show();          
            this.Close();
        }
        private void LoadGameClick(object sender, RoutedEventArgs e)
        {
            loadgame = new loadgame();
            loadgame.Show();
        }
        private void AboutGameClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tuto hru naprogramoval Dave z Bohnic", "O hře");
        }
        private void ExitGameClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

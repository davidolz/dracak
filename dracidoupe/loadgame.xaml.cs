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
using System.Windows.Shapes;

namespace dracidoupe
{
    /// <summary>
    /// Interaction logic for loadgame.xaml
    /// </summary>
    public partial class loadgame : Window
    {
        public loadgame()
        {
            InitializeComponent();
        }
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                fileDirectory.Text = filename;
            }
        }
        private void LoadClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alert!");
            this.Close();
        }
        }
     
}

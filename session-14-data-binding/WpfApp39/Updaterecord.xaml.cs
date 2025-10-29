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
using MySql.Data.MySqlClient;

namespace WpfApp39
{
    /// <summary>
    /// Interaction logic for Updaterecord.xaml
    /// </summary>
    public partial class Updaterecord : Window
    {
        Vehicle vehicle;
        public Updaterecord(String searchdata)
        {
            InitializeComponent();

            vehicle = new Vehicle();
            vehicle.Searchrec(searchdata); 
            this.DataContext = vehicle;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vehicle.Updaterec();
            MessageBox.Show("Saved");
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            speedtb.Clear();
            speedlimittb.Clear();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

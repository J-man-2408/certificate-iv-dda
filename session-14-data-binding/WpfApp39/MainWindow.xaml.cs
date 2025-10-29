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
using MySql.Data.MySqlClient;

namespace WpfApp39
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dbname = "xxx_traffic_cop";
        private string dbuser = "root";
        private string dbpassword = "";
        private int dbport = 3306;
        private string dbserver = "localhost";
        private string dbsslm = "none";
        private string dbconnectionString = "";
        private MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            dbconnectionString = String.Format("server={0};port={1};user={2};password={3};database={4};sslMode={5}", dbserver, dbport, dbuser, dbpassword, dbname, dbsslm);
            conn = new MySqlConnection(dbconnectionString);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (MySqlException ex)
            {
               MessageBox.Show("No DB Connection");
            }
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {

            string sqlQuery = "Select * from traffic;";
            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1]}: {rdr[2],5}kph");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "Select * from traffic where number_plate like '%" + SearchTextbox.Text + "%';";
            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1],5}: {rdr[2],5}kph: {rdr[3],5}:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }

        private void Deleterecord_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "Delete from traffic where number_plate like '%" + SearchTextbox.Text + "%';";
            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void Editrecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextbox.Text))
            {
                MessageBox.Show("Enter numberplate data in Search box ");
            }
            else
            {

                Updaterecord ob = new Updaterecord(SearchTextbox.Text);
                ob.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            insertwindow op1 = new insertwindow();
            op1.ShowDialog();
        }

       

        private void VehicleListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SpeedingCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery1 = "SELECT * FROM traffic WHERE  speed > speed_limit;";
            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery1, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1],5}: {rdr[2],5}kph: {rdr[3],5}:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void SpeedingCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            string sqlQuery1 = "SELECT * FROM traffic;";

            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery1, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1],5}: {rdr[2],5}kph: {rdr[3],5}:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery1 = "SELECT * FROM traffic WHERE  speed <= speed_limit;";
            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery1, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1],5}: {rdr[2],5}kph: {rdr[3],5}:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            string sqlQuery1 = "SELECT * FROM traffic;";

            try
            {
                VehicleListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery1, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleListbox.Items.Add($"{rdr[1],5}: {rdr[2],5}kph: {rdr[3],5}:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }

        private void Demerits_Click(object sender, RoutedEventArgs e)
        {
            List<Demerits> list = new List<Demerits>();
            string sqlQuery = "Select traffic.number_plate,demerits.demerit_points,demerits.penalty_points from traffic inner join demerits where number_plate like '%" + SearchTextbox.Text + "%';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Demerits dem = new Demerits();
                    dem.Number_Plate = Convert.ToString(rdr["number_plate"]);
                    dem.Demerit_Points = Convert.ToInt32(rdr["demerit_points"]);
                    dem.Penalty_Points = Convert.ToInt32(rdr["penalty_points"]);
                    list.Add(dem);
                }
                Datagrid.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
    public class Demerits
    {
        public string Number_Plate { get; set; }
        public int Demerit_Points { get; set; }
        public int Penalty_Points { get; set; }
    }
}


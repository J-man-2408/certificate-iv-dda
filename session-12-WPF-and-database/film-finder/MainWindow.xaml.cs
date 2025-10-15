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
using MySql.Data.MySqlClient;

namespace film_finder
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MySql.Data.MySqlClient.MySqlConnection connection;
        private readonly String dbServer = "127.0.0.1";
        private readonly String dbPort = "3306";
        private readonly String dbName = "sakila";

        // Should be reading these our of your environment
        private readonly String dbUser = "sakila_app_user";
        private readonly String dbPassword = "Hunter2!";
        public MainWindow()
        {
            InitializeComponent();
            connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = $"server={dbServer}; port={dbPort}; database={dbName}; uid={dbUser};pwd={dbPassword}";
        }


        private void SortingMode_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string tag = (string)button.Tag;

            FilmResults.Items.Clear();
            ErrorBox.Visibility = Visibility.Collapsed;
            string defaultQuery = "select * from film";

            if (tag == "alphabetical")
            {
                defaultQuery += " order by title";
            }
            else if (tag == "chronological asc")
            {
                defaultQuery += " order by release_year";
            }
            else if (tag == "chronological desc")
            {
                defaultQuery += " order by release_year desc";
            }

            try
            {
                connection.Open();
                MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(defaultQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FilmResults.Items.Add($"{reader[3]}, {reader[1]}: {reader[2]}");
                    //FilmResults.Items.Add($"{reader.GetString("release_year")}, {reader.GetString("title")}: {reader.GetString("description")}");

                }
            }
            catch (Exception ex)
            {

                ErrorBox.Text = ex.Message;
                ErrorBox.Visibility = Visibility.Visible;
            }finally
            {
                connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilmResults.Items.Clear();
            ErrorBox.Visibility = Visibility.Collapsed;
            string query = SearchBar.Text;
            string defaultQuery = $"select release_year, title, description from film where description like '%{query}%'";
            try
            {
                connection.Open();
                MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(defaultQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FilmResults.Items.Add($"{reader[0]}, {reader[1]}: {reader[2]}");
                    //FilmResults.Items.Add($"{reader.GetString("release_year")}, {reader.GetString("title")}: {reader.GetString("description")}");

                }

            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
                ErrorBox.Visibility = Visibility.Visible;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp39
{
    public class Vehicle
    {
       
        private string dbname = "xxx_traffic_cop";
        private string dbuser = "root";
        private string dbpassword = "";
        private int dbport = 3306;
        private string dbserver = "localhost";
        private string dbsslm = "none";
        private string dbconnectionString = "";
        private MySqlConnection conn;


        public string SearchNP { get; set; }
        public int ID { get; set; }
        public string NumberPlate { get; set; }
        public int Speed { get; set; }
        public int SpeedLimit { get; set; }

        public Vehicle()
        {
            dbconnectionString = String.Format("server={0};port={1};user={2};password={3};database={4};sslMode={5}", dbserver, dbport, dbuser, dbpassword, dbname, dbsslm);
            conn = new MySqlConnection(dbconnectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No DB Connection");
            }
            finally
            {
                conn.Close();
            }

        }

        public void Searchrec( string searchdata)
        {
            try
            {
                
                string sqlToRun = "Select id,number_plate,speed,speed_limit from traffic where number_plate = '" + searchdata + "'; ";
                SearchNP = searchdata;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlToRun, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["id"].ToString());
                    NumberPlate = rdr["number_plate"].ToString();
                    Speed = int.Parse(rdr[2].ToString());
                    SpeedLimit = int.Parse(rdr[3].ToString());



                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No record found");
            }
        }

        public void Updaterec()
        {
            try
            {

                string sqlToRun = "Update traffic set speed= " + Speed + ",speed_limit=  " + SpeedLimit + " where number_plate = '" + SearchNP + "';";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlToRun, conn);

                 cmd.ExecuteNonQuery();        
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("No record found");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

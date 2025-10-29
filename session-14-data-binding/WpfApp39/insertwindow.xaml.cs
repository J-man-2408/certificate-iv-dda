﻿using System;
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
    /// Interaction logic for insertwindow.xaml
    /// </summary>
    public partial class insertwindow : Window
    {
        
        public insertwindow()
        {
            InitializeComponent();
        }

        string dbconnectionString = "datasource=localhost; port=3306; username=root; password='';";
        
        public void cleardata()
        {
            IdText.Clear();
            NpText.Clear();
            SpText.Clear();
            SlText.Clear();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            cleardata();
        }

        public void insertrec()
        {
            MySqlConnection conn = new MySqlConnection(dbconnectionString);
            string sqlQuery = "Insert into xxx_traffic_cop.traffic values ('" + this.IdText.Text + "','" + this.NpText.Text + "','" + this.SpText.Text + "','" + this.SlText.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            try
            {
                
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sqlQuery, conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Added");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            insertrec();
        }
    }
}

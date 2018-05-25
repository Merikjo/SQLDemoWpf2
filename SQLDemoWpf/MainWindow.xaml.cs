using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace SQLDemoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SQL_Click(object sender, RoutedEventArgs e)
        {
            https://www.connectionstrings.com/sql-server/
            string connStr = "Server=DESKTOP-9M9UEOR;Database=Northwind;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "SELECT * FROM Customers WHERE Country = 'Finland'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string companyName = reader.GetString(1);
                string contactName = reader.GetString(2);
                MessageBox.Show("Löytyi rivi: " + companyName + " " + contactName);
            }

            // resurssien vapautus
            reader.Close();
            cmd.Dispose();
            conn.Dispose();

        }
    }
}

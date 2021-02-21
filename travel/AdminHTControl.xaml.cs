using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для AdminHTControl.xaml
    /// </summary>
    public partial class AdminHTControl : System.Windows.Controls.UserControl
    {
        public AdminHTControl()
        {
            InitializeComponent();
            FillDataGrid();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void FillDataGrid()

        {

        
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where country_num=Id_country";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            hotgrid.ItemsSource = dts.DefaultView;
            connection.Close();



        }
        private void deletehot_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to delete hottrip?", "delete hottrip", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("delete from   dbo.hottrips   where hot_id='" + pickedhot.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data del succs");
                        FillDataGrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    FillDataGrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void viewall_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void viewhot_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry,dbo.hottrips where country_num=Id_country and hot_id=Id_trip";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            hotgrid.ItemsSource = dts.DefaultView;
            connection.Close();

        }

        private void addhot_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.hottrips (hot_id) values ('" + pickedhot.Content +"') ", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            FillDataGrid();
        }
    }
}

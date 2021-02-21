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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для AdminPurCNTRL.xaml
    /// </summary>
    public partial class AdminPurCNTRL : UserControl
    {
        public AdminPurCNTRL()
        {
            InitializeComponent();
            FillDataGrid();
            fillcountrycombo();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");
        private void fillcountrycombo()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * from dbo.trip ";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);

            connection.Close();
           srchtr .ItemsSource = dts.DefaultView;
            srchtr.DisplayMemberPath = "Trip_title";
            srchtr.SelectedValuePath = "Id_trip";
        }
        private void FillDataGrid()

        {


            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT pudate,purus,putr,puchid, Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip,dbo.Users, dbo.tripcountry,dbo.purchases  where country_num=Id_country and Id_u=purus and Id_trip=putr";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            hotgrid.ItemsSource = dts.DefaultView;
            connection.Close();



        }
        private void viewppl_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT pudate,purus,putr,puchid, Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip,dbo.Users, dbo.tripcountry,dbo.purchases  where country_num=Id_country and Id_u=purus and Id_trip=putr and purus='" + searchppl.Text + "'";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            hotgrid.ItemsSource = dts.DefaultView;
            connection.Close();
        }

        private void searchtr(object sender, RoutedEventArgs e)
        {
            string cide = srchtr.SelectedValue.ToString();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT pudate,purus,putr,puchid, Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip,dbo.Users, dbo.tripcountry,dbo.purchases  where country_num=Id_country and Id_u=purus and Id_trip=putr and Trip_title='"+srchtr.Text +"'";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            hotgrid.ItemsSource = dts.DefaultView;
            connection.Close();
        }

        private void viewall_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
    }
}

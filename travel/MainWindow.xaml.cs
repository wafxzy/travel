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

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     public  int useride;
        public MainWindow()
        { 
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridCentral.Children.Clear();
                    string sqlExpressionhot = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry,dbo.hottrips where country_num=Id_country and hot_id=Id_trip";
                    connection.Open();
                    SqlCommand commandhot = new SqlCommand(sqlExpressionhot, connection);
                    SqlDataReader readerh = commandhot.ExecuteReader();
                    string pathimh;
                    while (readerh.Read())
                    {
                        HotOfferCNTRL j = new HotOfferCNTRL();
                        j.price.Text = readerh["price"].ToString();
                        j.ttl.Text = readerh["Trip_title"].ToString();
                        j.COUNTRY.Text = readerh["Country_name"].ToString();
                        j.DESCR.Text = readerh["Trip_Description"].ToString();
                        j.stars.Text = readerh["stars"].ToString();
                        pathimh = readerh["imgpath"].ToString();
                        j.triptypoe.Text = readerh["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri(pathimh));
                        j.tofavorites.Tag = readerh["Id_trip"].ToString();
                        j.favusid = useride.ToString();
                        GridCentral.Children.Add(j);

                    }
                    connection.Close();
                    break;
                case 1:
                    GridCentral.Children.Clear();
                    string sqlExpressionrest = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where  country_num=Id_country and  TripType_name<>'Mountains' and TripType_name<>'Sea'";
                    connection.Open();
                    SqlCommand commandrest = new SqlCommand(sqlExpressionrest, connection);
                    SqlDataReader readerr = commandrest.ExecuteReader();
                   
                    while (readerr.Read())
                    {
                        HotOfferCNTRL j = new HotOfferCNTRL();
                        j.price.Text = readerr["price"].ToString();
                        j.ttl.Text = readerr["Trip_title"].ToString();
                        j.COUNTRY.Text = readerr["Country_name"].ToString();
                        j.DESCR.Text = readerr["Trip_Description"].ToString();
                        j.stars.Text = readerr["stars"].ToString();
                        pathimh = readerr["imgpath"].ToString();
                        j.triptypoe.Text = readerr["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri(pathimh));
                        j.tofavorites.Tag = readerr["Id_trip"].ToString();
                        j.favusid = useride.ToString();
                        GridCentral.Children.Add(j);
                    }
                    connection.Close();
                    break;
                case 3:
                    GridCentral.Children.Clear();
                    string sqlExpression = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where country_num=Id_country and TripType_name='Sea'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    string pathim;
                    while (reader.Read())
                    {

                        HotOfferCNTRL j = new HotOfferCNTRL();
                        j.price.Text = reader["price"].ToString();
                        j.ttl.Text = reader["Trip_title"].ToString();
                        j.COUNTRY.Text = reader["Country_name"].ToString();
                        j.DESCR.Text = reader["Trip_Description"].ToString();
                        j.stars.Text = reader["stars"].ToString();
                        pathim = reader["imgpath"].ToString();
                        j.triptypoe.Text= reader["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri( pathim));
                        j.tofavorites.Tag= reader["Id_trip"].ToString();
                        j.favusid = useride.ToString();
                        GridCentral.Children.Add(j);

                    }
                    connection.Close();

                    break;
                case 2:
                    GridCentral.Children.Clear();
                    string sqlExpressionm = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where country_num=Id_country and TripType_name='Mountains'";
                    connection.Open();
                    SqlCommand commandm = new SqlCommand(sqlExpressionm, connection);
                    SqlDataReader readerm = commandm.ExecuteReader();
                    
                    while (readerm.Read())
                    {

                        HotOfferCNTRL j = new HotOfferCNTRL();
                        j.price.Text = readerm["price"].ToString();
                        j.ttl.Text = readerm["Trip_title"].ToString();
                        j.COUNTRY.Text = readerm["Country_name"].ToString();
                        j.DESCR.Text = readerm["Trip_Description"].ToString();
                        j.stars.Text = readerm["stars"].ToString();
                        pathim = readerm["imgpath"].ToString();
                        j.triptypoe.Text = readerm["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri(pathim));
                        j.tofavorites.Tag = readerm["Id_trip"].ToString();
                        j.favusid = useride.ToString();
                        GridCentral.Children.Add(j);

                    }
                    connection.Close();

                    break;
                case 4:
                    GridCentral.Children.Clear();
                    string sqlExpressionp = "SELECT pudate, Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip,dbo.purchases,dbo.Users, dbo.tripcountry where country_num=Id_country and Id_u=purus and Id_trip=putr and Id_u='" + useride.ToString() + "'";
                    connection.Open();
                    SqlCommand commandp = new SqlCommand(sqlExpressionp, connection);
                    SqlDataReader readerp = commandp.ExecuteReader();

                    while (readerp.Read())
                    {

                       purchasedCNTRl j = new purchasedCNTRl();
                        j.price.Text = readerp["price"].ToString();
                        j.ttl.Text = readerp["Trip_title"].ToString();
                        j.COUNTRY.Text = readerp["Country_name"].ToString();
                        j.DESCR.Text = readerp["Trip_Description"].ToString();
                        j.stars.Text = readerp["stars"].ToString();
                        pathim = readerp["imgpath"].ToString();
                        j.triptypoe.Text = readerp["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri(pathim));
                      j.PDATE.Content= readerp["pudate"].ToString();

                        GridCentral.Children.Add(j);

                    }
                    connection.Close();

                    break;
                case 5:
                    GridCentral.Children.Clear();
                    string sqlExpressionf = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip,dbo.fav,dbo.Users, dbo.tripcountry where country_num=Id_country and Id_u=intus and Id_trip=inttr and Id_u='"+useride.ToString()+"'";
                    connection.Open();
                    SqlCommand commandf = new SqlCommand(sqlExpressionf, connection);
                    SqlDataReader readerf = commandf.ExecuteReader();

                    while (readerf.Read())
                    {

                        FavControl j = new FavControl();
                        j.price.Text = readerf["price"].ToString();
                        j.ttl.Text = readerf["Trip_title"].ToString();
                        j.COUNTRY.Text = readerf["Country_name"].ToString();
                        j.DESCR.Text = readerf["Trip_Description"].ToString();
                        j.stars.Text = readerf["stars"].ToString();
                        pathim = readerf["imgpath"].ToString();
                        j.triptypoe.Text = readerf["TripType_name"].ToString();
                        j.imпtr.Source = new BitmapImage(new Uri(pathim));
                        j.buy.Tag = readerf["Id_trip"].ToString();
                        j.deletefromfav.Tag = readerf["Id_trip"].ToString();
                        j.favusid = useride.ToString();
                        GridCentral.Children.Add(j);

                    }
                    connection.Close();
                    break;


                default:
                    break;
            }
        }
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}

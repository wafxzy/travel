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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Drawing;

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для TripAdminControl.xaml
    /// </summary>
    public partial class TripAdminControl : System.Windows.Controls.UserControl
    {
        string imageurl = null;
        public TripAdminControl()
        {
            InitializeComponent();
            filltripgrid();
            fillcountrycombo();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void filltripgrid()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where country_num=Id_country";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            tripsgrid.ItemsSource = dts.DefaultView;
            connection.Close();

        }
        private void fillcountrycombo()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * from dbo.tripcountry ";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);

            connection.Close();
            countrytxt.ItemsSource = dts.DefaultView;
            countrytxt.DisplayMemberPath = "Country_name";
            countrytxt.SelectedValuePath = "Id_country";
        }
        private void browseimg_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                imageurl = op.FileName;
                imagebox.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void saveall_Click(object sender, RoutedEventArgs e)
        {
            string cide = countrytxt.SelectedValue.ToString();
        //    byte[] arr;
            ImageConverter converter = new ImageConverter();
            //   arr = (byte[])converter.ConvertTo(imagebox.Source, typeof(byte[]));
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.trip (Trip_title, TripType_name, stars, price,Trip_Description,Main_image,country_num, imgpath) values ('" + titletxt.Text + "','" + typetriptxt.Text + "' ,'" + starsupd.Text + "','" + pricetrip.Text + "','" + upddescrtxt.Text + "','" + imagebox + "', '"+cide+"','" + imageurl + "')", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            filltripgrid();
        }

        private void updtitle_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this title?", "updte title", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip set Trip_title ='" + titletxt.Text + "'  where Id_trip='" + PICKEDIDTRIP.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }

        }

        private void upddescr_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this description?", "updte descr", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip set Trip_Description ='" + upddescrtxt.Text + "'  where Id_trip='" + PICKEDIDTRIP.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void updTYPETRIP_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this triptypename?", "updte type name", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip set TripType_name ='" + typetriptxt.Text + "'  where Id_trip='" + PICKEDIDTRIP.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }

        } 
               
  
        private void updcountrytrip_Click(object sender, RoutedEventArgs e)
        {
            string cide= countrytxt.SelectedValue.ToString();
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this country?", "updte country", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip  set country_num='"+cide+"' where Id_trip='" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        
    }

        private void updstars_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this stars>", "updte stars", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip  set stars='" + starsupd.Text + "' where Id_trip='" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void updprice_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this price?", "updte price", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip  set price='" + pricetrip.Text + "' where Id_trip='" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void deletetrip_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want delete this trip", "delete trip", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("delete from   dbo.trip   where Id_trip='" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data deleted succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void updateimg_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this image?", "updte omage", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.trip  set Main_image='" + imagebox + "' where Id_trip='" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        connection.Open();
                        SqlCommand cmd1 = new SqlCommand("update   dbo.trip set imgpath = '" + imageurl + "' where Id_trip = '" + PICKEDIDTRIP.Content + "' ", connection);
                        cmd1.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
                        filltripgrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data n succs");
                    filltripgrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void srchtripbtn_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id_trip,Trip_title, TripType_name, stars, price,Trip_Description,Main_image,Country_name,imgpath,Id_country FROM dbo.trip, dbo.tripcountry where country_num=Id_country and '"+srchtrip.Text+ "'=Trip_title OR country_num=Id_country and '" + srchtrip.Text + "'=TripType_name or country_num=Id_country and '" + srchtrip.Text + "'=Trip_Description ";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            tripsgrid.ItemsSource = dts.DefaultView;
            connection.Close();
        }
    }
}

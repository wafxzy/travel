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
    /// Логика взаимодействия для FavControl.xaml
    /// </summary>
    public partial class FavControl : System.Windows.Controls.UserControl
    {
        public FavControl()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");
     DateTime   purchtime =DateTime.Now;
        public string favusid;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to buy this trip?", "trip buy", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {


                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Insert into dbo.purchases (purus ,putr,pudate ) values('" + favusid + "','" + buy.Tag + "','" + purchtime.ToString("u") + "')", connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("trip bought succs");

                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show(price.Text);

                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void callback_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoWindow m = new MoreInfoWindow();
            m.Show();
        }

        private void deletefromfav_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to delete from vavorite?", "delete favorite", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {


                        connection.Open();
                        SqlCommand cmd = new SqlCommand("delete from dbo.fav  where intus=  '" + favusid + "' and inttr='" + deletefromfav.Tag + "'", connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data deleted succs");

                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("Delete canceleds");

                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }
    }
}

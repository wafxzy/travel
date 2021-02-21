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
    /// Логика взаимодействия для HotOfferCNTRL.xaml
    /// </summary>
    public partial class HotOfferCNTRL : System.Windows.Controls.UserControl
    {
        public HotOfferCNTRL()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");
        public string favusid;
        private void tofavorites_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this paswword?", "updte password", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                      
                      
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Insert into dbo.fav (intus,inttr) values('" +  favusid + "','" + tofavorites.Tag + "')", connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data inserted succs");
                      
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
    }
}

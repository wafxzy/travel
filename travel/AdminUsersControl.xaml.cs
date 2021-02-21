using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace travel
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersControl.xaml
    /// </summary>
    public partial class AdminUsersControl : System.Windows.Controls.UserControl
    {
        public AdminUsersControl()
        {
            InitializeComponent();

            FillDataGrid();
        }SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void FillDataGrid()

        {            
                  connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText =  "SELECT Id_u, user_login, email, password_user, Ad_nametype FROM dbo.Users, dbo.admin_type where Admin_type=Ad_id";

            cmd.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
            dataadap.Fill(dts);
            usersgrid.ItemsSource = dts.DefaultView;
            connection.Close();

                     

        }

        private void updpss_Click(object sender, RoutedEventArgs e)
        {
               DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this paswword?", "updte password", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.Users set password_user ='" + passwtxt.Text + "'  where Id_u='" + pickedid.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
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

        private void updlog_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this login?", "updte login", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.Users set user_login ='" + logintxt.Text + "'  where Id_u='" + pickedid.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
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

        private void updemail_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to update this email?", "updte email", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("update   dbo.Users set email ='" + emailtxt.Text + "'  where Id_u='" + pickedid.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("data upd succs");
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

        private void delus_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("you want to delete this user ?", "delete user", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("delete from   dbo.Users   where Id_u='" + pickedid.Content + "'", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        System.Windows.MessageBox.Show("user deleted succs");
                        FillDataGrid();
                        break;

                    }
                case DialogResult.No:
                    System.Windows.MessageBox.Show("data safety");
                    FillDataGrid();
                    break;
                default:
                    System.Windows.MessageBox.Show("data n succs");
                    break;
            }
        }

        private void searchbtnuser_Click(object sender, RoutedEventArgs e)
        {
            if (userlogsrch.IsChecked==true)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id_u, user_login, email, password_user, Ad_nametype FROM dbo.Users, dbo.admin_type where Admin_type = Ad_id AND user_login='"+searchtxt.Text+"'", connection);

                DataTable dts = new DataTable();
                SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
                dataadap.Fill(dts);
                usersgrid.ItemsSource = dts.DefaultView;
                connection.Close();
            
            }
          else  if (usermailsrch.IsChecked==true)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id_u, user_login, email, password_user, Ad_nametype FROM dbo.Users, dbo.admin_type where Admin_type = Ad_id AND email='" + searchtxt.Text + "'", connection);

                DataTable dts = new DataTable();
                SqlDataAdapter dataadap = new SqlDataAdapter(cmd);
                dataadap.Fill(dts);
                usersgrid.ItemsSource = dts.DefaultView;
                connection.Close();
            }
            else
            {
                FillDataGrid();
            }
        }

        private void updrole_Click(object sender, RoutedEventArgs e)
        {
            if (usercheck.IsChecked==true)
            {
                DialogResult res = System.Windows.Forms.MessageBox.Show("you want to take over admin in this user ?", "Admin- user", MessageBoxButtons.YesNo);
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("update  dbo.Users  set Admin_type=1  where Id_u='" + pickedid.Content + "'", connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            System.Windows.MessageBox.Show("user acces type updated succs");
                            FillDataGrid();
                            break;

                        }
                    case DialogResult.No:
                        System.Windows.MessageBox.Show("data safety");
                        FillDataGrid();
                        break;
                    default:
                        System.Windows.MessageBox.Show("data n succs");
                        break;
                }
            }


            if (admincheck.IsChecked==true)
            {
                DialogResult res = System.Windows.Forms.MessageBox.Show("you want to give admin to this user ?", "Give Admin to this user", MessageBoxButtons.YesNo);
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("update  dbo.Users  set Admin_type=2  where Id_u='" + pickedid.Content + "'", connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            System.Windows.MessageBox.Show("user acces type updated succs");
                            FillDataGrid();
                            break;

                        }
                    case DialogResult.No:
                        System.Windows.MessageBox.Show("data safety");
                        FillDataGrid();
                        break;
                    default:
                        System.Windows.MessageBox.Show("data n succs");
                        break;
                }
            }
        }
    }
}

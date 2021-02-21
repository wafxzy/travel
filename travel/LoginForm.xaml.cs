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
using System.Windows.Shapes;

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox PB = (PasswordBox)sender;
            PB.Password = string.Empty;
            PB.GotFocus -= PasswordBox_GotFocus;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Regbtnlogf_Click(object sender, RoutedEventArgs e)
        {
            RegistrForm regf = new RegistrForm();
            Close();
            regf.Show();
        }
        public string idu;
        private void btnloginLogf_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length == 0)
            {
               Login.Text = "Enter an login.";
               Login.Focus();
            }
        
            else
            {
                string LOG = Login.Text;
                string password = passw.Password;
               
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from dbo.Users where user_login='" + LOG + "'  and password_user='" + password + "'", connection);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["user_login"].ToString() + " " + dataSet.Tables[0].Rows[0]["email"].ToString();
                   string adt = dataSet.Tables[0].Rows[0]["Admin_type"].ToString();
                    MessageBox.Show( username);//Sending value from one form to another form.  
                    if (int.Parse(adt)==1)
                    {
                        MainWindow m = new MainWindow();

                        HotOfferCNTRL h = new HotOfferCNTRL();
                       idu= dataSet.Tables[0].Rows[0]["Id_u"].ToString();
                        m.useride = int.Parse(idu);
                        h.favusid = idu;
                        m.Show(); Close();
                    }
                   else if (int.Parse(adt) == 2)
                    {
                        AdminWindow a = new AdminWindow();
                        a.Show();
                        Close();
                    }
                }
                else
                {
                   MessageBox.Show( "Sorry! Please enter existing emailid/password.");
                }
                connection.Close();
            }
        }
    }
}

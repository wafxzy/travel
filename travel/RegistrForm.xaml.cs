using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrForm.xaml
    /// </summary>
    public partial class RegistrForm : Window
    {
        public RegistrForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=traveldb;Integrated Security=True");

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void closeregformbtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox em = (TextBox)sender;
            em.Text = string.Empty;
            em.GotFocus -= email_GotFocus;
        }

        private void regLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox log = (TextBox)sender;
            log.Text = string.Empty;
            log.GotFocus -= regLogin_GotFocus;
        }

        private void regpassw_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox regp1 = (PasswordBox)sender;
            regp1.Password = string.Empty;
            regp1.GotFocus -= regpassw_GotFocus;
        }

        private void passwregrepeat_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox regp2 = (PasswordBox)sender;
            regp2.Password = string.Empty;
            regp2.GotFocus -= passwregrepeat_GotFocus;
        }
LoginForm lf=new LoginForm();
        private void btnregistrf_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text.Length == 0)
            {
               MessageBox.Show( "Enter an email.");
                email.Focus();
            }
            else if (!Regex.IsMatch(email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show( "Enter a valid email.");
               
                email.Focus();
            }
            else
            {
                string username = regLogin.Text;
               string emmail = email.Text;
                string password = regpassw.Password;
                if (regpassw.Password.Length == 0)
                {
                    MessageBox.Show( "Enter password.");
                    regpassw.Focus();
                }
                else if (passwregrepeat.Password.Length == 0)
                {
                    MessageBox.Show("Enter Confirm password.");
                    passwregrepeat.Focus();
                }
                else if (regpassw.Password != passwregrepeat.Password)
                {
                    MessageBox.Show("Confirm password must be same as password.");
                    passwregrepeat.Focus();
                }
                else
                {                
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into dbo.Users (user_login,email,password_user) values('" + username + "','" + emmail + "','" + password + "')", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("You have Registered successfully.");
                   
                }
            }
        }

        private void signinbtnref_Click(object sender, RoutedEventArgs e)
        {
            Close();
            lf.Show();
        }
    }
}

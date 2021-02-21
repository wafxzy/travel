using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для MoreInfoWindow.xaml
    /// </summary>
    public partial class MoreInfoWindow : Window
    {
        public MoreInfoWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void PhoneBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void Regbtnlogf_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnloginLogf_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("30watt83@gmail.com", "BotTesting");
            // кому отправляем
            MailAddress to = new MailAddress("wafxzy@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = $"<h2>name:::"+nameuser.Text+   "\t telephone::"+telephone.Text+"</h2>";
            
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
           
            smtp.Credentials = new NetworkCredential("30watt83@gmail.com", "exzystos");
            smtp.EnableSsl = true;
            smtp.Send(m);
            MessageBox.Show("Mail Succsesfully sent");
        }
    }
}

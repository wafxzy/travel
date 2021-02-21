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
using System.Windows.Shapes;

namespace travel
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
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
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridCentral.Children.Clear();
                    GridCentral.Children.Add(new AdminHTControl());




                    break;
                case 1:
                    GridCentral.Children.Clear();
                    
                    GridCentral.Children.Add(new TripAdminControl());
                    TripAdminControl t = new TripAdminControl();
                    GridCentral.Children.Add(t);
                    
                    break;

                case 2:
                    GridCentral.Children.Clear();

                    GridCentral.Children.Add(new AdminUsersControl());
                    break;
                case 3:
                    GridCentral.Children.Clear();

                    GridCentral.Children.Add(new AdminPurCNTRL());
                    break;
                default:
                    break;
            }
        }
    }
}

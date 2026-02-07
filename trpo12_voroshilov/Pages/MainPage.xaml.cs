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

using trpo12_voroshilov.Service;

namespace trpo12_voroshilov.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UsersService service { get; set; } = new();
        public User? user { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void To_Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }
        private void To_Edit(object sender, RoutedEventArgs e)
        {
            if (user == null)
                MessageBox.Show("Выберите пользователя!");
            else
                NavigationService.Navigate(new UsersPage(user));
        }
    }
}

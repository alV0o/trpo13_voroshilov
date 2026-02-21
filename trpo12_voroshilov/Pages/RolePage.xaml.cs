using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using trpo12_voroshilov.Models;
using trpo12_voroshilov.Service;

namespace trpo12_voroshilov.Pages
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public Role Role { get; set; } = new();
        UsersService usersService = new();
        public ObservableCollection<User> Users { get; set; } = new();
        public RolePage()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Users.Clear();
            foreach (var user in usersService.Users)
            {
                if (Role.Title == user.Role.Title)
                {
                    Users.Add(user);
                }
            }
        }
    }
}

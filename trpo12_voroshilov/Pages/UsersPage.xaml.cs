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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private UsersService _usersService = new();
        private User _user = new();
        bool isEdit = false;
        public UsersPage(User? user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                _user = user;
                isEdit = true;
            }
            DataContext = _user;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_user.Username) && !string.IsNullOrEmpty(_user.Email) && !string.IsNullOrEmpty(_user.Login) && !string.IsNullOrEmpty(_user.Password))
            {
                if (isEdit)
                    _usersService.Commit();
                else
                {
                    _user.CreatedAt = DateTime.Now;
                    _usersService.Add(_user);
                }
                MessageBox.Show("Добавлен");
                NavigationService.GoBack();
            }
            else MessageBox.Show("Заполните все поля!");
        }
    }
}

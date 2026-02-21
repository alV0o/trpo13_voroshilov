using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.IO;
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
using trpo12_voroshilov.Models;
using trpo12_voroshilov.Service;

namespace trpo12_voroshilov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserProfile.xaml
    /// </summary>
    public partial class AddEditUserProfile : Page
    {
        private UsersService _usersService = new();
        private User _user = new();
        public AddEditUserProfile(User user)
        {
            InitializeComponent();
            if (user.UserProfile == null)
            {
                user.UserProfile = new();
            }
            _user = user;
            DataContext = _user;
        }

        private void SaveAndBack_Click(object sender, RoutedEventArgs e)
        {

            if (_user.UserProfile.Birthday == null && _user.UserProfile.AvatarUrl == null && _user.UserProfile.Bio == null && _user.UserProfile.Phone == null)
            {
                _user.UserProfile = null;
            }
            else
            {
                if (Validation.GetHasError(phoneTextBox))
                {
                    MessageBox.Show("Исправьте ошибки!");
                    return;
                }

                _usersService.Commit();
            }
            NavigationService.GoBack();
        }
    }
}

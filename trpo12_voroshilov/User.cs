using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo12_voroshilov
{
    public class User : ObservableObject
    {
        private int _id;
        public int Id 
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _login;
        public string Login 
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        private string _username;
        public string Username 
        { 
            get =>_username;
            set => SetProperty(ref _username, value);
        }
        private string _email;
        public string Email
        { 
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        { 
            get=>_password;
            set=>SetProperty(ref _password, value);
        }
        private DateTime _createdat;
        public DateTime CreatedAt 
        { 
            get=>_createdat;
            set=>SetProperty(ref _createdat,value);
        }
    }
}

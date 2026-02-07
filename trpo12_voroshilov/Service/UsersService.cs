using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using trpo12_voroshilov.Data;

namespace trpo12_voroshilov.Service
{
    public class UsersService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<User> Users { get; set; } = new();
        public UsersService() 
        {
            GetAll();
        }
        public void Add(User user)
        {
            var _user = new User()
            {
                Id = user.Id,
                Login = user.Login,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
            };
            _db.Add(_user);
            Commit();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Users.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

    }
}

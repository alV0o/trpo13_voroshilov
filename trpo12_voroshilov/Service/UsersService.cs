using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using trpo12_voroshilov.Data;
using trpo12_voroshilov.Models;

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
                UserProfile = user.UserProfile,
                RoleId = user.RoleId,
                Role = user.Role,
            };
            _db.Add(_user);
            Commit();
            Users.Add(_user);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Users
                            .Include(u=>u.UserProfile)
                            .Include(u=>u.Role)
                            .ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

    }
}

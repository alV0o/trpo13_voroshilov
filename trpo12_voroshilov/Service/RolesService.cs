using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using trpo12_voroshilov.Data;
using trpo12_voroshilov.Models;
using static System.Net.Mime.MediaTypeNames;

namespace trpo12_voroshilov.Service
{
    public class RolesService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; set; } = new();
        public RolesService()
        {
            GetAll();
        }
        public void Add(Role role)
        {
            var _role = new Role()
            {
                Title = role.Title,
            };
            _db.Add<Role>(_role);
            Commit();
            Roles.Add(_role);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var roles = _db.Roles.ToList();
            Roles.Clear();
            foreach (var user in roles)
            {
                Roles.Add(user);
            }
        }

        public void LoadRelation(Role role, string relation)
        {
            var entry = _db.Entry(role);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
            if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}

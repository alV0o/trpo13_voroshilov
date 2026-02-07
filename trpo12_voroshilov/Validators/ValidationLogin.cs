using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using trpo12_voroshilov.Service;

namespace trpo12_voroshilov.Validators
{
    public class ValidationLogin : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value as string;

            if (string.IsNullOrEmpty(login)) return new ValidationResult(false, "Обязательное поле!");
            UsersService _usersService = new();

            if (login.Length < 5) return new ValidationResult(false, "Длина минимум 5 символов!");

            if (_usersService.Users.Where(l => l.Login.ToLower() == login.ToLower()).Count() > 0) return new ValidationResult(false, "Такой логин существует!");

            return ValidationResult.ValidResult;
        }
    }
}

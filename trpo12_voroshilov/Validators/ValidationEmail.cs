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
    public class ValidationEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;

            if (string.IsNullOrEmpty(email)) return new ValidationResult(false, "Обязательное поле!");

            bool isEmail = false;
            int counter = 0;

            //с 1 индекса тк @ минимум 2 символ
            for(int i = 1; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    counter++;
                    isEmail = true;
                }
                if (counter > 1) return new ValidationResult(false, "@ - уникальный символ!");
            }

            if (!isEmail) return new ValidationResult(false, "Почта должна содержать @ после адреса");
            UsersService _usersService = new UsersService();
            
            if (_usersService.Users.Where(l => l.Email.ToLower() == email.ToLower()).Count() > 0) return new ValidationResult(false, "Такая почта существует!");

            return ValidationResult.ValidResult;
        }
    }
}

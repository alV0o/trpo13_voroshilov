using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo12_voroshilov.Validators
{
    public class ValidationPassword:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;

            if (string.IsNullOrEmpty(password)) return new ValidationResult(false, "Обязательное поле!");
            if (password.Length < 8) return new ValidationResult(false, "Длина минимум 8 символов!");
            
            bool hasSymbol = false;
            bool hasNumber = false;
            bool hasUpper = false;
            bool hasLower = false;
            char[] symbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '`', '~', '_', '-', '=', '+', '\\', '?', '/', '|'};

            foreach (char letter in password)
            {
                if (Char.IsLower(letter)) hasLower = true;
                else if (Char.IsUpper(letter)) hasUpper = true;
                else if (Char.IsDigit(letter)) hasNumber = true;
                else if (symbols.Contains(letter)) hasSymbol = true;
            }

            if (hasLower == false) return new ValidationResult(false, "Пароль должен содержать буквы в нижнем регистре!");
            else if (hasUpper == false) return new ValidationResult(false, "Пароль должен содержать буквы в верхнем регистре!");
            else if (hasNumber == false) return new ValidationResult(false, "Пароль должен содержать цифры!");
            else if (hasSymbol == false) return new ValidationResult(false, "Пароль должен содержать символы!");

            return ValidationResult.ValidResult;
        }
    }
}

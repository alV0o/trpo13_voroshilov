using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo12_voroshilov.Validators
{
    public class ValidationPhone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = value as string;
            long temp = 0;
            if (!long.TryParse(phone, out temp))
            {
                return new ValidationResult(false, "Только цифры!");
            }
            if (phone.Length < 11 || phone.Length>11)
            {
                return new ValidationResult(false, "длина 11 символов!");
            }
            else if (phone[0] != '8')
            {
                return new ValidationResult(false, "должно начинаться с 8!");
            }

            return ValidationResult.ValidResult;
        }
    }
}

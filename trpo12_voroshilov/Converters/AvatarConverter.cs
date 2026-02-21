using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace trpo12_voroshilov.Converters
{
    public class AvatarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string path = (string)value;

            string basePath = "pack://siteoforigin:,,,";

            path = string.Concat(basePath, path);

            Uri uri = new Uri(path, UriKind.Absolute);

            try
            {
                if (Application.GetRemoteStream(uri) != null)
                {
                    return path;
                }
            }
            catch
            {
                return null;
            }

            return null;


           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

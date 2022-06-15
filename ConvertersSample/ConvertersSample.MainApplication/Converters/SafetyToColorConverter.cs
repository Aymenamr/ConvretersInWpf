using ConvertersSample.MainApplication.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ConvertersSample.MainApplication.Converters
{
    public class SafetyToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (((Safety)value).Equals(Safety.Dangerous))
                    return "Red";
                else if (((Safety)value).Equals(Safety.Risky))
                    return "Orange";
                else if (((Safety)value).Equals(Safety.Safe))
                    return "Green";

                return "White";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

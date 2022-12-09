using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Realty
{
    class ConverterValue : IValueConverter
    {
        public static readonly ConverterValue Instanse = new ConverterValue();
        //конвертирование даты
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ((DateTime)value).ToString("dd.MM.yyyy");
            }
            else
            { return null; }
        }
        //обратное конвертирование даты
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

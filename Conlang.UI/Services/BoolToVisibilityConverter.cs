using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace Conlang.UI.Services
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is bool && (bool)value)
        //        return Visibility.Visible;
        //    else
        //        return Visibility.Collapsed;
        //}
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = value is bool boolValue && boolValue;

            if (parameter != null && parameter.ToString() == "Inverted")
                isVisible = !isVisible;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
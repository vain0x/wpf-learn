using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfLearn.Examples;

// usage: RadioButton.IsChecked={Binding SelectedValue, Converter={StaticResource RadioCheckConverter}, ConverterParameter=ExpectedValue}

[ValueConversion(typeof(object), typeof(bool))]
public class RadioCheckConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Equals(value, parameter);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var isChecked = (bool?)value;
        if (isChecked == true)
        {
            return parameter;
        }

        // If unset, B cannot be selected
        return DependencyProperty.UnsetValue;

        // If null, check is sometimes removed.
        //return null;
    }
}

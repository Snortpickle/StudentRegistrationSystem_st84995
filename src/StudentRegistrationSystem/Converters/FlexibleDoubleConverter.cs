using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentRegistrationSystem.Converters;

/// <summary>
/// Allows entering GPA with either '.' or ',' as decimal separator.
/// Formats values using invariant culture (dot).
/// </summary>
public sealed class FlexibleDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null) return string.Empty;

        return value switch
        {
            double d => d.ToString(CultureInfo.InvariantCulture),
            float f => f.ToString(CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var s = (value as string)?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(s))
            return 0d;

        // Accept both separators by normalizing to dot and parsing with invariant culture
        s = s.Replace(',', '.');

        // Allow inputs like "8." (valid in invariant float parsing)
        if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
            return result;

        return Binding.DoNothing;
    }
}

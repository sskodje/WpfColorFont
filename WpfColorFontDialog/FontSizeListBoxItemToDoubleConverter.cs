using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfColorFontDialog
{
	public class FontSizeListBoxItemToDoubleConverter : IValueConverter
	{
		public FontSizeListBoxItemToDoubleConverter()
		{
		}

		object System.Windows.Data.IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ListBoxItem item = value as ListBoxItem;
			return double.Parse(item.Content.ToString());
		}

		object System.Windows.Data.IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
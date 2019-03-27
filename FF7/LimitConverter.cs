using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FF7
{
	class LimitConverter : IValueConverter
	{
		private static uint[] param = new uint[] { 0x1, 0x2, 0x8, 0x10, 0x40, 0x80, 0x200 };
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < param.Length; i++)
			{
				if (param[i] == (int)(uint)value) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return param[(int)value];
		}
	}
}

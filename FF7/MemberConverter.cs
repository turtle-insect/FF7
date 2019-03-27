using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FF7
{
	class MemberConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < Info.Instance().Members.Count; i++)
			{
				if (Info.Instance().Members[i].Value == (uint)value) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().Members[(int)value].Value;
		}
	}
}

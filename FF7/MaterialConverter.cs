using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FF7
{
	class MaterialConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < Info.Instance().Materias.Count; i++)
			{
				if (Info.Instance().Materias[i].Value == (uint)value) return i;
			}
			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().Materias[(int)value].Value;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FF7
{
    /// <summary>
    /// ChoiceWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ChoiceWindow : Window
    {
		public enum eType
		{
			eItem,
			eWeapon,
			eArmor,
			eAccessory,
		};

		public uint ID { get; set; }
		public eType Type { get; set; } = eType.eItem;

		public ChoiceWindow()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			var item = (NameValueInfo)ListBoxItem.SelectedItem;
			ID = item.Value;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			var items = Info.Instance().Items;
			if (Type == eType.eWeapon) items = Info.Instance().Weapons;
			else if (Type == eType.eArmor) items = Info.Instance().Armors;
			else if (Type == eType.eAccessory) items = Info.Instance().Accessorys;

			foreach (var item in items)
			{
				if (String.IsNullOrEmpty(filter) || item.Name.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(item);
				}
			}
		}
	}
}

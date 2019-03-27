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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace FF7
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			Load(files[0], false);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;
			Load(dlg.FileName, false);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;
			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void ComboBoxSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SaveData.Instance().Adventure = (uint)ComboBoxSave.SelectedIndex;
		}

		private void ButtonItemChoice_Click(object sender, RoutedEventArgs e)
		{
			Item item = (sender as Button)?.DataContext as Item;
			var dlg = new ChoiceWindow();
			dlg.ID = item.ID;
			dlg.ShowDialog();
			item.ID = dlg.ID;
		}

		private void ButtonWeaponChoice_Click(object sender, RoutedEventArgs e)
		{
			var chara = ListBoxParty.SelectedItem as Charactor;
			if (chara == null) return;

			var dlg = new ChoiceWindow();
			dlg.Type = ChoiceWindow.eType.eWeapon;
			dlg.ID = chara.Weapon;
			dlg.ShowDialog();
			chara.Weapon = dlg.ID;
		}

		private void Load(String filename, bool force)
		{
			if (SaveData.Instance().Open(filename, force) == false)
			{
				MessageBox.Show(Properties.Resources.MessageLoadFail);
				return;
			}

			DataContext = new DataContext();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}
	}
}

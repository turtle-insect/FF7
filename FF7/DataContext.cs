using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF7
{
	class DataContext
	{
		public Info Info { get; set; } = Info.Instance();
		public ObservableCollection<Charactor> Charactors { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Materia> Materias { get; set; } = new ObservableCollection<Materia>();

		public DataContext()
		{
			foreach(var member in Info.Instance().Members)
			{
				if (member.Value >= 9) continue;
				Charactors.Add(new Charactor(member.Name, 93 + member.Value * 132));
			}
			for (uint i = 0; i < 320; i++)
			{
				Items.Add(new Item(1285 + i * 2));
			}
			for (uint i = 0; i < 200; i++)
			{
				Materias.Add(new Materia(1925 + i * 4));
			}
		}

		public uint Gil
		{
			get { return SaveData.Instance().ReadNumber(0x0B85, 4); }
			set { Util.WriteNumber(0x0B85, 4, value, 0, 9999999); }
		}

		public uint GP
		{
			get { return SaveData.Instance().ReadNumber(0x0CF7, 2); }
			set { Util.WriteNumber(0x0CF7, 2, value, 0, 10000); }
		}

		public uint Party1
		{
			get { return SaveData.Instance().ReadNumber(0x0501, 1); }
			set { Util.WriteNumber(0x0501, 1, value, 0, 0xFF); }
		}

		public uint Party2
		{
			get { return SaveData.Instance().ReadNumber(0x0502, 1); }
			set { Util.WriteNumber(0x0502, 1, value, 0, 0xFF); }
		}

		public uint Party3
		{
			get { return SaveData.Instance().ReadNumber(0x0503, 1); }
			set { Util.WriteNumber(0x0503, 1, value, 0, 0xFF); }
		}
	}
}

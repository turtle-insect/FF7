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

		public DataContext()
		{
			List<String> party = new List<string>{ "Cloud", "Barret", "Tifa", "Aeris's", "Red XIII", "Yuffie", "Cait Sith", "Vincent", "Cid" };
			for(uint i = 0; i < party.Count; i++)
			{
				Charactors.Add(new Charactor(party[(int)i], 93 + i * 132));
			}
			for (uint i = 0; i < 320; i++)
			{
				Items.Add(new Item(1285 + i * 2));
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FF7
{
    class Item : INotifyPropertyChanged
    {
		private readonly uint mAddress;
		public event PropertyChangedEventHandler PropertyChanged;

		public Item(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2) & 0x01FF; }
			set
			{
				var tmp = SaveData.Instance().ReadNumber(mAddress, 2) & 0xFE00;
				tmp = tmp | value;
				SaveData.Instance().WriteNumber(mAddress, 2, tmp);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 1, 1) >> 1; }
			set
			{
				if (value < 0) value = 0;
				if (value > 99) value = 99;
				var tmp = SaveData.Instance().ReadNumber(mAddress, 2) & 0x01FF;
				tmp = tmp | (value << 9);
				SaveData.Instance().WriteNumber(mAddress, 2, tmp);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}

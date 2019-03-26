using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF7
{
    class Charactor
    {
		private readonly uint mAddress;
		private readonly String mName;

		public ObservableCollection<Materia> Materias { get; set; } = new ObservableCollection<Materia>();

		public Charactor(String name, uint address)
		{
			mAddress = address;
			mName = name;

			for (uint i = 0; i < 16; i++)
			{
				Materias.Add(new Materia(address + 0x40 + i * 4));
			}
		}

		public String Name
		{
			get { return mName; }
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x01, 1); }
			set { Util.WriteNumber(mAddress + 0x01, 1, value, 1, 99); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x3C, 4); }
			set { Util.WriteNumber(mAddress + 0x3C, 4, value, 0, 9999999); }
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x2C, 2); }
			set { Util.WriteNumber(mAddress + 0x2C, 2, value, 0, 9999); }
		}

		public uint MaxHP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x38, 2); }
			set { Util.WriteNumber(mAddress + 0x38, 2, value, 1, 9999); }
		}

		public uint MP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x30, 2); }
			set { Util.WriteNumber(mAddress + 0x30, 2, value, 0, 9999); }
		}

		public uint MaxMP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x3A, 2); }
			set { Util.WriteNumber(mAddress + 0x3A, 2, value, 1, 9999); }
		}

		public uint Strength
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x02, 1); }
			set { Util.WriteNumber(mAddress + 0x02, 1, value, 0, 255); }
		}

		public uint Vitality
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x03, 1); }
			set { Util.WriteNumber(mAddress + 0x03, 1, value, 0, 255); }
		}

		public uint Magic
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x04, 1); }
			set { Util.WriteNumber(mAddress + 0x04, 1, value, 0, 255); }
		}

		public uint Spirit
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x05, 1); }
			set { Util.WriteNumber(mAddress + 0x05, 1, value, 0, 255); }
		}

		public uint Dexterity
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x06, 1); }
			set { Util.WriteNumber(mAddress + 0x06, 1, value, 0, 255); }
		}

		public uint Luck
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0x07, 1); }
			set { Util.WriteNumber(mAddress + 0x07, 1, value, 0, 255); }
		}
	}
}

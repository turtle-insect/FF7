using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7
{
    class Materia
    {
		private readonly uint mAddress;

		public Materia(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 1); }
			set { SaveData.Instance().WriteNumber(mAddress, 1, value); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 1, 3); }
			set { SaveData.Instance().WriteNumber(mAddress + 1, 3, value); }
		}
	}
}

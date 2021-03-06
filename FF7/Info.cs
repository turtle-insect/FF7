﻿using System;
using System.Collections.Generic;

namespace FF7
{
	class Info
	{
		private static Info mThis;
		public List<NameValueInfo> Items { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Weapons { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Armors { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Accessorys { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Materias { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Members { get; private set; } = new List<NameValueInfo>();

		private Info() { }

		public static Info Instance()
		{
			if (mThis == null)
			{
				mThis = new Info();
				mThis.Init();
			}
			return mThis;
		}

		public NameValueInfo Search<Type>(List<Type> list, uint id)
			where Type : NameValueInfo, new()
		{
			int min = 0;
			int max = list.Count;
			for (; min < max;)
			{
				int mid = (min + max) / 2;
				if (list[mid].Value == id) return list[mid];
				else if (list[mid].Value > id) max = mid;
				else min = mid + 1;
			}
			return null;
		}

		private void Init()
		{
			AppendList("info\\item.txt", Items);
			AppendList("info\\weapon.txt", Weapons);
			AppendList("info\\armor.txt", Armors);
			AppendList("info\\accessory.txt", Accessorys);
			AppendList("info\\materia.txt", Materias);
			AppendList("info\\member.txt", Members);
		}

		private void AppendList<Type>(String filename, List<Type> items)
			where Type : ILineAnalysis, new()
		{
			if (!System.IO.File.Exists(filename)) return;
			String[] lines = System.IO.File.ReadAllLines(filename);
			foreach (String line in lines)
			{
				if (line.Length < 3) continue;
				if (line[0] == '#') continue;
				String[] values = line.Split('\t');
				if (values.Length < 2) continue;
				if (String.IsNullOrEmpty(values[0])) continue;
				if (String.IsNullOrEmpty(values[1])) continue;

				Type type = new Type();
				if(type.Line(values))
				{
					items.Add(type);
				}
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class TableCollection : IEnumerable
	{
		private List<BaseTable> tables = new List<BaseTable>();
		private int counter = 0;
		private String tableFilePath = null;

		public TableCollection()
		{

		}

		public TableCollection(String tableFilePath)
		{
			this.tableFilePath = tableFilePath;
		}

		public BaseTable this[Type type]
		{
			get
			{
				foreach (BaseTable baseTable in tables)
				{
					if (baseTable.DataType == type)
					{
						return baseTable;
					}
				}

				throw new IndexOutOfRangeException();
			}
		}

		public Table<T> GetTable<T>() where T : Cell, new()
        {
			Type type = typeof(T);

            foreach (BaseTable table in tables)
            {
                if (table.DataType == type)
                {
					return (Table<T>)table;
                }
            }

			throw new TypeLoadException();
        }

		public BaseTable this[int index]
		{
			get
			{
				return tables[index];
			}
		}


		public String TableFilePath
		{
			get { return tableFilePath; }
			set { tableFilePath = value; }
		}

		public BaseTable[] ToArray()
		{
			return tables.ToArray();
		}

		public bool LoadTables()
		{
			using (StreamReader sr = new StreamReader(tableFilePath, System.Text.Encoding.Default))
			{
				if (sr.ReadLine() == "<DocStart>")
				{
					Comand comand = new Comand();
					bool endReading = false;
					while (endReading == false)
					{
						comand.getComand(sr.ReadLine());
						if (comand.IsComand)
						{
							switch (comand.Paramert)
							{
								case "Table":
									foreach (BaseTable table in tables)
									{
										if (table.DataType.Name == comand.Value)
										{
											table.LoadTable(sr, comand);
										}
									}
									break;

								case "DocEnd":
									endReading = true;
									break;

								default:
									break;
							}
						}

					}
					if (tables.Count != 0)
					{
						counter = tables[tables.Count - 1].ID;
					}
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public void SaveTables()
		{
			using (StreamWriter sw = new StreamWriter(tableFilePath, false, System.Text.Encoding.Default))
			{
				sw.WriteLine("<DocStart>");

				foreach (BaseTable table in tables)
				{
					table.SaveTable(sw);
				}

				sw.WriteLine("<DocEnd>");
			}
		}

		public void AddTable(Type type)
		{
			Type genericTableType = typeof(Table<>).MakeGenericType(type);
			tables.Add((BaseTable)Activator.CreateInstance(genericTableType, ++counter));
		}

		public void AddTable<T>(Table<T> import) where T : Cell, new()
		{
			Table<T> table = new Table<T>(++counter, import.Name);
			table.Name = import.Name;

			foreach (T cell in import)
			{
				table.AddWithoutReindexation(cell);
			}

			tables.Add(table);
		}

		public bool UpdateTable(BaseTable import)
		{
			for (int i = 0; i < tables.Count; i++)
			{
				if (tables[i].ID == import.ID && tables[i].DataType == import.DataType)
				{
					tables[i] = import;
					return true;
				}
			}
			return false;
		}

		public bool RemoveTable(int id)
		{
			for (int i = 0; i < tables.Count; i++)
			{
				if (tables[i].ID == id)
				{
					tables.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		public bool RemoveTable(BaseTable table)
		{
			return tables.Remove(table);
		}

		public bool RemoveTable(Type type)
		{
			for (int i = 0; i < tables.Count; i++)
			{
				if (tables[i].DataType == type)
				{
					tables.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return (IEnumerator)GetEnumerator();
        }

		private TabCollEnum GetEnumerator()
        {
			return new TabCollEnum(tables);
        }
	}

    internal class TabCollEnum : IEnumerator
    {
		List<BaseTable> tables = null;
		int position = -1;

		public TabCollEnum(List<BaseTable> tables)
        {
			this.tables = tables;
        }

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public BaseTable Current
		{
			get
			{
				return tables[position];
			}
		}

		public bool MoveNext()
        {
			position++;
			return (position < tables.Count);
        }

        public void Reset()
        {
			position = -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class TableCollection
	{
		private List<BaseTable> tables = new List<BaseTable>();
		private int counter = 0;
		private String tableFilePath = null;


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

				return null;
            }
        }


		public String TableFilePath
        {
            get { return tableFilePath; }
            set { tableFilePath = value; }
        }

		public List<BaseTable> Tables
		{
			get { return tables; }
		}

		public TableCollection()
        {

        }

		public TableCollection(String tableFilePath)
        {
			this.tableFilePath = tableFilePath;
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
										if (table.DataType.Name == comand.Argument)
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

		public BaseTable GetTable(Type type)
        {
            foreach (BaseTable table in tables)
            {
                if (table.DataType == type)
                {
					return table;
                }
            }
			return null;
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
	}
}

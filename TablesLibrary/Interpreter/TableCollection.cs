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
		private List<Table> tables = new List<Table>();
		private int counter = 0;
		public String tableFilePath = null;

		public List<Table> Tables
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

		public bool loadTables()
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
									foreach (Table table in tables)
									{
										if (table.DataType.Name == comand.Argument)
										{
											table.loadTable(sr);
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
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public void saveTables()
		{
			using (StreamWriter sw = new StreamWriter(tableFilePath, false, System.Text.Encoding.Default))
			{
				sw.WriteLine("<DocStart>");

				foreach (Table table in tables)
				{
					table.saveTable(sw);
				}

				sw.WriteLine("<DocEnd>");
			}
		}

		public void AddTable(Table table)
		{
			table.ID = ++counter;
			tables.Add(table);
		}

		public void AddTable(Cell type)
		{
			tables.Add(new Table(++counter, type));
		}

		public Table getTable(int id)
		{
			foreach (Table table in tables)
			{
				if (table.ID == id)
				{
					return table;
				}
			}
			return null;
		}

		public Table getTable(String name)
		{
			foreach (Table table in tables)
			{
				if (table.name == name)
				{
					return table;
				}
			}
			return null;
		}

		public bool updateTable(Table import)
		{
			for (int i = 0; i < tables.Count; i++)
			{
				if (tables[i].ID == import.ID)
				{
					tables[i] = import;
					return true;
				}
			}
			return false;
		}

		public bool removeTable(int id)
		{
			for (int i = 0; i < tables.Count; i++)
			{
				if (tables[i].ID == id)
				{
					tables.Remove(tables[i]);
					return true;
				}
			}
			return false;
		}
	}
}

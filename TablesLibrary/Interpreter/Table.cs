using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class Table<Te> where Te : Cell, new()
	{
		protected int id = 0;
		protected String name = "";
		protected List<Te> cells = new List<Te>();

		private int counter = 0;

		public int ID
		{
			get { return id; }
		}

		public String Name
		{
			get { return name; }
		}

		public int LastId
		{
			get { return counter; }
		}

		public List<Te> Cells
		{
			get { return cells; }
		}

		public Table(int id)
		{
			this.id = id;
		}

		public Table(int id, String name)
		{
			this.id = id;
			this.name = name;
		}

		public bool addElement()
		{
			//Cell cell = (Cell)Activator.CreateInstance(this.dataType, ++counter);
			Te cell = (Te)Activator.CreateInstance(typeof(Te), ++counter);
			cells.Add(cell);

			return true;
		}

		public bool addElement(Te import)
		{
			Te cell = (Te)Activator.CreateInstance(typeof(Te), ++counter);
			if (cell.UpdateThis(import))
			{
				cells.Add(cell);
				return true;
			}
			else
			{
				return false;
			}
		}


		public bool UpdateElement(Te cell)
		{
			for (int i = 0; i < cells.Count; i++)
			{
				if (cells[i].ID == cell.ID)
				{
					cells[i] = cell;
					return true;
				}
			}
			return false;
		}

		public void saveTable(StreamWriter streamWriter)
		{
			streamWriter.Write(this.tableDeclaration(0));
			streamWriter.Write(Cell.formatParam(nameof(id), id, 1));
			streamWriter.Write(Cell.formatParam(nameof(name), name, 1));

			foreach (Cell cell in this.cells)
			{
				cell.saveCell(streamWriter);
			}

			streamWriter.WriteLine("<Table>");
			streamWriter.WriteLine();
		}

		public void loadTable(StreamReader streamReader, Comand comand)
		{
			bool endReading = false;
			String dataName = typeof(Te).Name;

			while (endReading == false)
			{
				comand.getComand(streamReader.ReadLine());
				if (comand.IsComand)
				{
					if (comand.Paramert == dataName)
					{
						//Te cell = (Te)Activator.CreateInstance(typeof(Te));
						Te cell = new Te();
						cell.loadCell(streamReader, comand);
						cells.Add(cell);
					}
					else
					{
						switch (comand.Paramert)
						{
							case "id":
								this.id = Convert.ToInt32(comand.Argument);
								break;
							case "name":
								this.name = comand.Argument;
								break;
							case "Table":
								endReading = true;
								break;

							default:
								break;
						}
					}
				}
			}
			if (cells.Count != 0)
			{
				counter = cells[cells.Count - 1].ID;
			}
		}

		public Cell GetElement(int index)
		{
			foreach (Cell item in cells)
			{
				if (item.ID == index)
				{
					return item;
				}
			}
			return null;
		}

		public Cell GetLastElement
		{
			get
			{
				return cells[cells.Count - 1];
			}
		}

		private String tableDeclaration(int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}
			return export + "<Table: " + typeof(Te).Name + ">\n";
		}
	}
}

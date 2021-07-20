using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class Table<Te> : BaseTable where Te : Cell, new()
	{
		protected List<Te> cells = new List<Te>();

		private int counter = 0;

		public int LastId
		{
			get { return counter; }
		}

		public Te[] Cells
		{
			get { return cells.ToArray(); }
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

		public bool AddElement()
		{
			Te cell = (Te)Activator.CreateInstance(typeof(Te), ++counter);
			cells.Add(cell);

			return true;
		}

		public bool AddElement(Te import)
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

		public override void SaveTable(StreamWriter streamWriter)
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

		public override void LoadTable(StreamReader streamReader, Comand comand)
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

		public Te GetElement(int index)
		{
			foreach (Te item in cells)
			{
				if (item.ID == index)
				{
					return item;
				}
			}
			return null;
		}

		public Te GetLastElement
		{
			get
			{
				return cells[cells.Count - 1];
			}
		}

        public override Type DataType => typeof(Te);

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

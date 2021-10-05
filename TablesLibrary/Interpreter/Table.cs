using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.Attributes;

namespace TablesLibrary.Interpreter
{
    public class Table<Te> : BaseTable, IEnumerable where Te : Cell, new()
    {
		protected List<Te> cells = new List<Te>();

		private Te defaultCell = new Te();
		public Te DefaultCell
        {
            get { return defaultCell; }
        }

		private int counter = 0;

		public int LastId
		{
			get { return counter; }
		}

		public override Type DataType => typeof(Te);

		public Te[] ToArray()
		{
			return cells.ToArray();
		}

		public Table()
        {

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

		public Te this[int index]
        {
            get
            {
				return cells[index];
            }
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

		public bool AddWithoutReindexation(Te import)
		{
			cells.Add(import);
			return true;
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
			streamWriter.Write(Cell.FormatParam(nameof(id), id, 0, 1));
			streamWriter.Write(Cell.FormatParam(nameof(name), name, "", 1));

			TableCellAttribute attribute = (TableCellAttribute)Attribute.GetCustomAttribute(typeof(Te), typeof(TableCellAttribute));

			if (attribute.IsAutoSave)
            {
				foreach (Te cell in cells)
				{
					cell.saveCell(streamWriter, defaultCell);
				}
			}
            else
            {
				foreach (Te cell in cells)
				{
					cell.saveCell(streamWriter);
				}
			}

			streamWriter.WriteLine("<Table>");
			streamWriter.WriteLine();
		}

		public override void LoadTable(StreamReader streamReader, Comand comand)
		{
			bool endReading = false;
			//String dataName = typeof(Te).Name;

			TableCellAttribute attribute = (TableCellAttribute)Attribute.GetCustomAttribute(typeof(Te), typeof(TableCellAttribute));
			String dataName = attribute.DataSaveName;

			while (endReading == false)
			{
				comand.getComand(streamReader.ReadLine());
				if (comand.IsComand)
				{
					if (comand.Paramert == dataName)
					{
						Te cell = new Te();
						cell.loadCell(streamReader, comand);
						cells.Add(cell);
					}
					else
					{
						switch (comand.Paramert)
						{
							case "id":
								this.id = Convert.ToInt32(comand.Value);
								break;
							case "name":
								this.name = comand.Value;
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

		public Te GetElementByIndex(int index)
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

		private String tableDeclaration(int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}

			TableCellAttribute attribute = (TableCellAttribute)Attribute.GetCustomAttribute(typeof(Te), typeof(TableCellAttribute));
			return export + "<Table: " + attribute.DataSaveName + ">\n";
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return (IEnumerator)GetEnumerator();
        }

		private TableEnum<Te> GetEnumerator()
		{
			return new TableEnum<Te>(cells);
		}
	}

    internal class TableEnum<T> : IEnumerator where T : Cell, new()
	{
		private List<T> list;
		private int position = -1;

        public TableEnum(List<T> table)
        {
			this.list = table;
        }

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public T Current
		{
			get
			{
				return list[position];
			}
		}

		public bool MoveNext()
        {
			position++;
			return (position < list.Count);
        }

        public void Reset()
        {
			position = -1;
        }
    }
}

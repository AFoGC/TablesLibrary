using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class Table//<Te> where Te : Cell, new()
	{
		protected int id = 0;
		public String name = "";
		protected List<Cell> cells = new List<Cell>();
		protected Type dataType = typeof(Cell);

		private int counter = 0;

		public int ID
		{
			set { id = value; }
			get { return id; }
		}

		public Type DataType
		{
			get { return dataType; }
			private set
            {
                if (value.BaseType == dataType)
                {
					dataType = value;
                }
                else
                {
					throw new Exception("Не верно задан тип данных в таблице. Тип данных, который вы хотите задать в табличе должен быть унаследован от класса Cell");
				}
            }
		}

		public List<Cell> Cells
		{
			get { return cells; }
		}

		public Table(Type type)
		{
			DataType = type;
		}

		public Table(int id, Type type)
		{
			this.id = id;
			DataType = type;
		}

		public Table(int id, String name, Type type)
		{
			this.id = id;
			this.name = name;
			DataType = type;
		}

		public bool addElement(Cell item)
		{
			if (item.GetType() == dataType)
			{
				cells.Add(item);
				return true;
			}
			return false;
		}

		public bool addElement()
        {
			Cell cell = (Cell)Activator.CreateInstance(this.dataType);
			cell.ID = ++counter;
			cells.Add(cell);

			return true;
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

		public void loadTable(StreamReader streamReader)
		{
			Comand comand = new Comand();
			bool endReading = false;
			String dataName = dataType.Name;

			while (endReading == false)
			{
				comand.getComand(streamReader.ReadLine());
				if (comand.IsComand)
				{
					if (comand.Paramert == dataName)
					{
						Cell cell = (Cell)Activator.CreateInstance(this.dataType);
						cell.loadCell(streamReader);
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

		public Cell getElemnt(int index)
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

		public bool updateElement(Cell cell)
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

		private String tableDeclaration(int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}
			return export + "<Table: " + dataType.Name + ">\n";
		}
	}
}

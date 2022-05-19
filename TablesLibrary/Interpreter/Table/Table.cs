using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public abstract class Table<Te> : BaseTable, IEnumerable where Te : Cell, new()
    {
		protected ObservableCollection<Te> cells = new ObservableCollection<Te>();

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

		public abstract override void ConnectionsSubload(TableCollection tablesCollection);

		public Te[] ToArray()
		{
			return cells.ToArray();
		}

        private void Table_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			TableCollection.TableChanged();
		}

		public Table()
		{
            cells.CollectionChanged += Cells_CollectionChanged;
		}

        private void Cells_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
			OnCollectionChanged(e);
        }

        public Table(int id) : this()
		{
			this.id = id;
		}

		public Table(int id, String name) : this(id)
		{
			this.name = name;
		}

		public Te this[int index]
        {
            get
            {
				return cells[index];
            }
        }

		public int Count
        {
            get { return cells.Count; }
        }


		public bool AddElement(Te import)
		{
			import.ID = ++counter;
			import.ParentTable = this;
			cells.Add(import);

			return true;
		}

        public bool AddElement()
		{
			Te cell = new Te();
			AddElement(cell);

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

		public bool Remove(Te remove)
        {
			bool removed = cells.Remove(remove);
            if (removed)
            {
				remove.ID = 0;
				remove.ParentTable = null;
				remove.ActivateCellRemoved();
			}
			return removed;
        }

		public void RemoveAll(Boolean restartCounter)
        {
			while (cells.Count > 0)
			{
				Remove(cells[0]);
			}
			if (restartCounter) counter = 0;
		}

		public void RemoveAll()
		{
			while (cells.Count > 0)
			{
				Remove(cells[0]);
			}
			counter = 0;
		}

		public void WipeAllInfo()
		{
			RemoveAll();
			id = 0;
			name = "";
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
				if (cells.Count != 0)
				{
					return cells[cells.Count - 1];
				}
                else
                {
					return DefaultCell;
                }
			}
		}

		public override void SaveTable(StreamWriter streamWriter)
		{
			streamWriter.Write(this.tableDeclaration(0));
			streamWriter.Write(Cell.FormatParam(nameof(id), id, 0, 1));
			streamWriter.Write(Cell.FormatParam(nameof(name), name, "", 1));

			//TableCellAttribute attribute = (TableCellAttribute)Attribute.GetCustomAttribute(typeof(Te), typeof(TableCellAttribute));

			Te defCell = new Te();

			foreach (Te cell in cells)
			{
				cell.saveCell(streamWriter, defCell);
			}


			streamWriter.WriteLine("<Table>");
			streamWriter.WriteLine();
		}

		public override void LoadTable(StreamReader streamReader, Comand comand)
		{
			this.RemoveAll();
			bool endReading = false;

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
						this.AddElement(cell);
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

		private String tableDeclaration(int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}

			TableCellAttribute attribute = (TableCellAttribute)Attribute.GetCustomAttribute(typeof(Te), typeof(TableCellAttribute));
			String savename;
            if (attribute == null)
            {
				savename = typeof(Te).Name;
			}
            else
            {
				savename = attribute.DataSaveName;
			}
			return export + "<Table: " + savename + ">\n";
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetEnumerator();
        }

		private TableEnum<Te> GetEnumerator()
		{
			return new TableEnum<Te>(cells);
		}
	}

    internal class TableEnum<T> : IEnumerator where T : TableCell.Cell, new()
	{
		private IEnumerator enumerator;

        public TableEnum(ObservableCollection<T> table)
        {
			this.enumerator = table.GetEnumerator();
        }
		public object Current => enumerator.Current;
		public bool MoveNext() => enumerator.MoveNext();
		public void Reset() => enumerator.Reset();
    }
}

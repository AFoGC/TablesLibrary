using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.Table;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter
{
	public class TableCollection : IEnumerable
	{
		private List<BaseTable> tables = new List<BaseTable>();
		private int counter = 0;
		private String tableFilePath = null;

		public event EventHandler TableLoading;
		public event EventHandler TableLoad;
		public event EventHandler TableSaving;
		public event EventHandler TableSave;
		public event EventHandler CellInTablesChanged;

        public Encoding FileEncoding { get; set; }

		public TableCollection()
		{
			FileEncoding = Encoding.Default;
		}

        public TableCollection(String tableFilePath) : this()
		{
			this.tableFilePath = tableFilePath;
		}

		internal void TableChanged()
        {
			EventHandler handler = CellInTablesChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary> 
		/// Метод, что вызывает метод ConnectionsSubload во всех таблицах коллекци 
		/// </summary>
		public void ConnectionsSubload()
        {
            foreach (BaseTable table in tables)
            {
				table.ConnectionsSubload(this);
            }
        }

		public void PresaveChanges()
        {
			foreach (BaseTable table in tables)
			{
				table.PresaveChages(this);
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


		/// <summary>
		/// Загружает коллекцию таблиц из указанного пути в TableFilePath
		/// </summary>
		/// <returns></returns>
		public bool LoadTables()
		{
			EventHandler handler1 = TableLoading;
			if (null != handler1) handler1(this, EventArgs.Empty);

			bool export;
			using (StreamReader sr = new StreamReader(tableFilePath, FileEncoding))
			{
				if (sr.ReadLine() == "<DocStart>")
				{
					Comand comand = new Comand();
					bool endReading = false;
					TableCellAttribute attribute;
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
										attribute = (TableCellAttribute)Attribute.GetCustomAttribute(table.DataType, typeof(TableCellAttribute));
                                        if (attribute != null)
                                        {
											if (attribute.DataSaveName == comand.Value)
											{
												table.LoadTable(sr, comand);
											}
										}
                                        else
                                        {
                                            if (table.GetType().Name == comand.Value)
                                            {
												table.LoadTable(sr, comand);
											}
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
					export = true;
				}
				else
				{
					export = false;
				}
			}

			this.ConnectionsSubload();

			EventHandler handler = TableLoad;
			if (null != handler) handler(this, EventArgs.Empty);

			return export;
		}

		/// <summary>
		/// Сохраняет таблицу по указанному пути в TableFilePath
		/// </summary>
		public void SaveTables()
		{
			PresaveChanges();

			EventHandler handler1 = TableSaving;
			if (null != handler1) handler1(this, EventArgs.Empty);

			using (StreamWriter sw = new StreamWriter(tableFilePath, false, FileEncoding))
			{
				sw.WriteLine("<DocStart>");

				foreach (BaseTable table in tables)
				{
					table.SaveTable(sw);
				}

				sw.WriteLine("<DocEnd>");
			}

			EventHandler handler2 = TableSave;
			if (null != handler2) handler2(this, EventArgs.Empty);
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

		/// <summary> 
		/// Возвращает таблицу, что содержит элементы указанного типа
		/// </summary>
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

			return null;
		}

		public BaseTable this[int index]
		{
			get
			{
				return tables[index];
			}
		}

		public void AddTable(Type type)
		{
			Type genericTableType = typeof(Table<>).MakeGenericType(type);
			BaseTable baseTable = (BaseTable)Activator.CreateInstance(genericTableType, ++counter);

			baseTable.TableCollection = this;
			tables.Add(baseTable);
		}

		public void AddTable<T>(Table<T> import) where T : Cell, new()
		{
			import.TableCollection = this;
			import.ID = ++counter;

			tables.Add(import);
		}

		public void RemoveAllTables(Boolean restartCounter)
		{
			while (tables.Count > 0)
			{
				RemoveTable(tables[0]);
			}
			if (restartCounter) counter = 0;
		}

		public bool RemoveTable(BaseTable table)
		{
			bool removed = tables.Remove(table);
            if (removed)
            {
				table.TableCollection = null;
			}
			return removed;
		}

		public bool RemoveTable(int tableId)
		{
			BaseTable table = null;
			foreach (var item in tables)
			{
				if (item.ID == tableId)
				{
					table = item;
					break;
				}
			}
			return RemoveTable(table);
		}

		public bool RemoveTable(Type type)
		{
			BaseTable table = null;
            foreach (var item in tables)
            {
                if (item.DataType == type)
                {
					table = item;
                }
            }
			return RemoveTable(table);
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return new TabCollEnum(tables);
        }
	}

    internal class TabCollEnum : IEnumerator
    {
		IEnumerator enumerator;
		public TabCollEnum(List<BaseTable> tables)
        {
			enumerator = tables.GetEnumerator();
        }
		public object Current => enumerator.Current;
		public bool MoveNext() => enumerator.MoveNext();
		public void Reset() => enumerator.Reset();
    }
}

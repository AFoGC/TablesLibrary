using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.Attributes;

namespace TablesLibrary.Interpreter
{
	public abstract class Cell
	{
		//
		//
		[Field("id")]
		private int id = 0;

		public int ID
		{
			get { return id; }
		}

		public Cell()
		{

		}

		public Cell(int id)
		{
			this.id = id;
		}


		protected abstract void updateThisBody(Cell cell);
		protected abstract void saveBody(StreamWriter streamWriter);
		protected abstract void loadBody(Comand comand);

		protected void saveBody(StreamWriter streamWriter, Cell defaultCell)
		{
			Type thisType = this.GetType();
			Type defType = defaultCell.GetType();

			FieldInfo[] thisFields = thisType.GetFields();
			FieldInfo[] defFields = defType.GetFields();

			String savename = "";
			for (int i = 0; i < thisFields.Length; i++)
			{
				if (thisFields[i].GetCustomAttribute<FieldAttribute>() != null)
				{
					savename = thisFields[i].GetCustomAttribute<FieldAttribute>().FieldName;
					streamWriter.Write(FormatParam(savename, thisFields[i].GetValue(this), defFields[i].GetValue(defaultCell), 2));
				}
			}
		}

		public bool UpdateThis(Cell cell)
		{
			if (this.GetType() == cell.GetType())
			{
				updateThisBody(cell);

				return true;
			}
			else
			{
				return false;
			}
		}

		public void saveCell(StreamWriter streamWriter)
		{
			streamWriter.Write(formatMark(this.GetType(), 1));
			streamWriter.Write(FormatParam("id", id, 0, 2));
			this.saveBody(streamWriter);
			streamWriter.Write(formatMark(this.GetType(), 1));
		}

		public void saveCell(StreamWriter streamWriter, Cell defaultCell)
		{
			streamWriter.Write(formatMark(this.GetType(), 1));
			this.saveBody(streamWriter, defaultCell);
			streamWriter.Write(formatMark(this.GetType(), 1));
		}

		public void loadCell(StreamReader streamReader, Comand comand)
		{
			bool endReading = false;

			while (endReading == false)
			{
				comand.getComand(streamReader.ReadLine());
				if (comand.IsComand)
				{

					//Переделать условие this.GetType().Name
					if (this.GetType().Name != comand.Paramert)
					{
                        if (comand.Paramert != "id")
                        {
							loadBody(comand);
						}
                        else
						{
							this.id = Convert.ToInt32(comand.Value);
						}
					}
					else
					{
						endReading = true;
					}
				}
			}
		}


		//--------------------------------------formatParam static methods------------------------------------------------

		public static String FormatParam<T>(String variableName, T item, T defaultValue, int countOfTabulations)
		{
			String export;
            if (!EqualityComparer<T>.Default.Equals(item, defaultValue))
            {
				export = FormatToString(item, defaultValue);
				export = formatComand(variableName, export);

				for (int i = 0; i < countOfTabulations; i++)
				{
					export = "\t" + export;
				}
			}
            else
            {
				export = "";
            }

			return export;
		}

		private static String formatComand(String parametr, String argument)
		{
			return "<" + parametr + ": " + argument + ">\n";
		}
		
		public static String formatMark(Type type, int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}
			return export + "<" + type.Name + ">\n";
		}
		
		public static String FormatToString<T>(T item, T defaultValue)
		{
			if (EqualityComparer<T>.Default.Equals(item, defaultValue))
			{
				return "";
			}
			else
			{
				if (item.GetType() == typeof(DateTime))
				{
					DateTime exp = (DateTime)(object)item;
					return formatDate(exp);
				}
				else
				{
					return item.ToString();
				}
			}
		}

		private static String formatDate(DateTime date)
		{
			String export = "";

			if (date.Day < 10)
			{
				export = export + "0" + date.Day.ToString();
			}
			else
			{
				export = export + date.Day.ToString();
			}
			export = export + ".";

			if (date.Month < 10)
			{
				export = export + "0" + date.Month.ToString();
			}
			else
			{
				export = export + date.Month.ToString();
			}
			export = export + ".";

			return export + date.Year.ToString();
		}

		//---------------------------get data static methods------------------------------------------

		public static DateTime readDate(String data)
		{
			try
			{
				return new DateTime(
				Convert.ToInt32("" + data[6] + data[7] + data[8] + data[9]),
				Convert.ToInt32("" + data[3] + data[4]),
				Convert.ToInt32("" + data[0] + data[1])
				);
			}
			catch
			{
				return new DateTime();
			}
		}
	}
}

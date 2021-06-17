using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class Cell
	{
		//
		//
		protected int id = 0;

		public int ID
		{
			set { id = value; }
			get { return id; }
		}

		public Cell()
		{

		}

		public Cell(int id)
		{
			this.id = id;
		}

		protected virtual void saveBody(StreamWriter streamWriter)
		{
			streamWriter.Write(formatParam(nameof(id), id, 2));
		}

		public void saveCell(StreamWriter streamWriter)
		{
			streamWriter.Write(formatMark(this.GetType(), 1));
			this.saveBody(streamWriter);
			streamWriter.Write(formatMark(this.GetType(), 1));
		}

		protected virtual void loadBody(Comand comand)
		{
			switch (comand.Paramert)
			{
				case "id":
					this.id = Convert.ToInt32(id);
					break;

				default:
					break;
			}
		}

		public void loadCell(StreamReader streamReader)
		{
			Comand comand = new Comand();
			bool endReading = false;

			while (endReading == false)
			{
				comand.getComand(streamReader.ReadLine());
				if (comand.IsComand)
				{
					if (this.GetType().Name != comand.Paramert)
					{
						loadBody(comand);
					}
					else
					{
						endReading = true;
					}
				}
			}
		}



		public static String formatParam(String variableName, int item, int countOftabulations)
		{
			if (item == 0)
			{
				return "";
			}
			else
			{
				String export = "";
				for (int i = 0; i < countOftabulations; i++)
				{
					export = export + "\t";
				}

				return export + "<" + variableName + ": " + item.ToString() + ">\n";
			}
		}

		public static String formatParam(String variableName, sbyte item, int countOftabulations)
		{
			if (item == -1)
			{
				return "";
			}
			else
			{
				String export = "";
				for (int i = 0; i < countOftabulations; i++)
				{
					export = export + "\t";
				}

				return export + "<" + variableName + ": " + item.ToString() + ">\n";
			}
		}

		public static String formatParam(String variableName, String item, int countOfTabulations)
		{
			if (item != "")
			{
				String export = "";
				for (int i = 0; i < countOfTabulations; i++)
				{
					export = export + "\t";
				}
				return export + "<" + variableName + ": " + item + ">\n";
			}
			return "";
		}

		public static String formatParam(String variableName, bool item, int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}

			return export + "<" + variableName + ": " + item.ToString() + ">\n";
		}
		/*
		public static String formatParam(String variableName, DateOfFilm date, int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}

			return export + "<" + variableName + ": " + date.ToString() + ">\n";
		}
		*/
		public static String formatMark(Type type, int countOfTabulations)
		{
			String export = "";
			for (int i = 0; i < countOfTabulations; i++)
			{
				export = export + "\t";
			}
			return export + "<" + type.Name + ">\n";
		}
	}
}

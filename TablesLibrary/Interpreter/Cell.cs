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


		//--------------------------------------------------------------------------------------

		public static String formatParam(String variableName, int item, int countOftabulations)
		{
			String export = formatToString(item);
			
            if (export == "")
            {
				return export;
            }
            else
            {
				//export = "<" + variableName + ": " + export + ">\n";
				export = formatComand(variableName, export);

                for (int i = 0; i < countOftabulations; i++)
                {
					export = "\t" + export;
                }
				return export;
            }
		}

		public static String formatParam(String variableName, sbyte item, int countOftabulations)
		{
			/*
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
			*/
			String export = formatToString(item);
            if (export == "")
            {
				return export;
            }
            else
            {
				export = formatComand(variableName, export);

                for (int i = 0; i < countOftabulations; i++)
                {
					export = "\t" + export;
                }

				return export;
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
		
		public static String formatParam(String variableName, DateTime item, int countOfTabulations)
		{
            if (item.Year == 1)
            {
				return "";
            }
            else
            {
				String export = "";
				for (int i = 0; i < countOfTabulations; i++)
				{
					export = export + "\t";
				}

				return export + "<" + variableName + ": " + formatDate(item) + ">\n";
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

		//---------------------------------------------------------------------

		public static String formatToString(int item)
		{
			if (item == 0)
			{
				return "";
			}
			else
			{
				return item.ToString();
			}
		}

		public static String formatToString(sbyte item)
		{
			if (item == -1)
			{
				return "";
			}
			else
			{
				return item.ToString();
			}
		}

		public static String formatToString(String item)
        {
			return item;
        }

		public static String formatToString(DateTime date)
        {
            if (date.Year == 1)
            {
				return "";
            }
            else
            {
				return formatDate(date);
			}
        }

		//---------------------------------------------------------------------

		public static DateTime readDate(String data)
        {
			return new DateTime (
				Convert.ToInt32("" + data[6] + data[7] + data[8] + data[9]),
				Convert.ToInt32("" + data[3] + data[4]),
				Convert.ToInt32("" + data[0] + data[1])
			);
        }
	}
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.Attributes;

namespace TablesLibrary.Interpreter
{
	public abstract class Cell : INotifyPropertyChanged
	{
		[Field("id")]
		private int id = 0;

		public int ID
		{
			get { return id; }
			set { id = value; OnPropertyChanged(nameof(ID)); }
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

			String savename;
			FieldAttribute fieldAttrib;
			for (int i = 0; i < thisFields.Length; i++)
			{
				fieldAttrib = (FieldAttribute)thisFields[i].GetCustomAttributes(typeof(FieldAttribute));
				if (fieldAttrib != null)
				{
					savename = fieldAttrib.FieldName;
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
				return item.ToString();
			}
		}

		public void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;

namespace TablesLibraryTests.TestFilmClasses
{
	class TestCell1 : Cell
	{
		private String name = "";
		private bool watched = false;
		private sbyte mark = -1;
		private DateTime date = new DateTime();

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

		public bool Watched
		{
			get { return watched; }
			set { watched = value; }
		}

		public sbyte Mark
		{
			get { return mark; }
			set { mark = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public TestCell1() : base() { }
		public TestCell1(int id) : base(id) { }

		protected override void updateThisBody(Cell cell)
		{
			TestCell1 loacalCell = (TestCell1)cell;

			this.name = loacalCell.name;
			this.watched = loacalCell.watched;
			this.mark = loacalCell.mark;
			this.mark = loacalCell.mark;
		}

		protected override void saveBody(StreamWriter streamWriter)
		{
			streamWriter.Write(formatParam(nameof(id), id, 2));
			streamWriter.Write(formatParam(nameof(name), name, 2));
			streamWriter.Write(formatParam(nameof(watched), watched, 2));
			streamWriter.Write(formatParam(nameof(mark), mark, 2));
			streamWriter.Write(formatParam(nameof(date), date, 2));
		}

		protected override void loadBody(Comand comand)
		{
			switch (comand.Paramert)
			{
				case "id":
					this.id = Convert.ToInt32(comand.Argument);
					break;
				case "name":
					this.name = comand.Argument;
					break;
				case "watched":
					this.watched = Convert.ToBoolean(comand.Argument);
					break;
				case "mark":
					this.mark = Convert.ToSByte(comand.Argument);
					break;
				case "date":
					this.date = readDate(comand.Argument);
					break;

				default:
					break;
			}
		}
	}
}

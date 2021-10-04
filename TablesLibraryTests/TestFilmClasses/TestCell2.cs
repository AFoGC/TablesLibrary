using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;

namespace TablesLibraryTests.TestFilmClasses
{
	class TestCell2 : Cell
	{
		private int count = 0;
		private String name = "";

		public int Count
		{
			get { return count; }
			set { count = value; }
		}

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

		public TestCell2() : base() { }
		public TestCell2(int id) : base(id) { }

		protected override void saveBody(StreamWriter streamWriter)
		{
			streamWriter.Write(formatParam(nameof(id), id, 2));
			streamWriter.Write(formatParam(nameof(count), count, 2));
			streamWriter.Write(formatParam(nameof(name), name, 2));
		}

        protected override void loadBody(Comand comand)
        {
			switch (comand.Paramert)
			{
				case "id":
					this.id = Convert.ToInt32(comand.Value);
					break;
				case "count":
					this.count = Convert.ToInt32(comand.Value);
					break;
				case "name":
					this.name = comand.Value;
					break;

				default:
					break;
			}
		}

		protected override void updateThisBody(Cell cell)
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;

namespace TablesLibraryTests.ACommonTest.Cells
{
	class Genre : Cell
	{
		private String name = "";
		private bool isSerialGenre = false;

		public Genre() : base() { }
		public Genre(int id) : base(id) { }

		protected override void loadBody(Comand comand)
		{
			switch (comand.Paramert)
			{
				case "id":
					this.id = Convert.ToInt32(comand.Value);
					break;
				case "name":
					this.name = comand.Value;
					break;
				case "isSerialGenre":
					this.isSerialGenre = Convert.ToBoolean(comand.Value);
					break;

				default:
					break;
			}
		}

		protected override void saveBody(StreamWriter streamWriter)
		{
			streamWriter.Write(FormatParam(nameof(id), id, 0, 2));
			streamWriter.Write(FormatParam(nameof(name), name, "", 2));
			streamWriter.Write(FormatParam(nameof(isSerialGenre), isSerialGenre, false, 2));
		}

		protected override void updateThisBody(Cell cell)
		{
			Genre genre = (Genre)cell;

			this.name = genre.name;
			this.isSerialGenre = genre.isSerialGenre;
		}
	}
}

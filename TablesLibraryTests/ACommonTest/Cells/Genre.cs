using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Attributes;

namespace TablesLibraryTests.ACommonTest.Cells
{
	[TableCell("Genre")]
	public class Genre : Cell
	{
        private string name = "";
        private bool isSerialGenre = false;

        public Genre() : base() { }
        public Genre(int id) : base(id) { }

        protected override void updateThisBody(Cell cell)
        {
            Genre genre = (Genre)cell;

            name = genre.name;
            isSerialGenre = genre.isSerialGenre;
        }

        protected override void saveBody(StreamWriter streamWriter)
        {
            streamWriter.Write(FormatParam(nameof(name), name, "", 2));
            streamWriter.Write(FormatParam(nameof(isSerialGenre), isSerialGenre, false, 2));
        }
        protected override void loadBody(Comand comand)
        {

            switch (comand.Paramert)
            {
                case "name":
                    name = comand.Value;
                    break;
                case "isSerialGenre":
                    isSerialGenre = Convert.ToBoolean(comand.Value);
                    break;

                default:
                    break;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsSerialGenre
        {
            get { return isSerialGenre; }
            set { isSerialGenre = value; }
        }
    }
}

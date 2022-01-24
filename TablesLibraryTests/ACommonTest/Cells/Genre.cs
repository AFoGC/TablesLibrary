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
    [TableCell("Genre", true)]
    public class Genre : Cell
    {
        [Field("Name")]
        private String name;
        [Field("IsSerial")]
        private Boolean isSerial;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Boolean IsSerial
        {
            get { return isSerial; }
            set { isSerial = value; }
        }

        protected override void loadBody(Comand comand)
        {
            /*
            switch (comand.Paramert)
            {
                case "name":
                    name = comand.Value;
                    break;
                case "isSerial":
                    isSerial = Convert.ToBoolean(comand.Value);
                    break;

                default:
                    break;
            }
            */
            throw new NotImplementedException();
        }

        protected override void updateThisBody(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}

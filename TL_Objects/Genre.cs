using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TL_Objects
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

        protected override void updateThisBody(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}

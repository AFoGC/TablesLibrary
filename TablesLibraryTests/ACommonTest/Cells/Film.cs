using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;

namespace TablesLibraryTests.ACommonTest.Cells
{
    public class Film : Cell
    {
        protected override void loadBody(Comand comand)
        {
            throw new NotImplementedException();
        }

        protected override void saveBody(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }

        protected override void updateThisBody(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}

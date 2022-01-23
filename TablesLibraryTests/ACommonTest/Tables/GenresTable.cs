using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;

namespace TablesLibraryTests.ACommonTest.Tables
{
    public class GenresTable : Table<Genre>
    {
        public override void ConnectionsSubload(TableCollection tablesCollection)
        {
            
        }
    }
}

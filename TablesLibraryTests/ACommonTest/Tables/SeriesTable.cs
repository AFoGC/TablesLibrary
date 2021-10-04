using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;

namespace TablesLibraryTests.ACommonTest.Tables
{
    public class SeriesTable : Table<Serie>
    {
        public SeriesTable(int id) : base(id)
        {

        }

        public SeriesTable(int id, String name) : base(id, name)
        {

        }
    }
}

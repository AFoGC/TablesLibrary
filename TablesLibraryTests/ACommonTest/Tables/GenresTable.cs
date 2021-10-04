using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;

namespace TablesLibraryTests.ACommonTest.Tables
{
    class GenresTable : Table<Genre>
    {
        public GenresTable(int id) : base(id)
        {

        }

        public GenresTable(int id, String name) : base(id, name)
        {

        }
    }
}

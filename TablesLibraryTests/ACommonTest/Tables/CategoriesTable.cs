using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;

namespace TablesLibraryTests.ACommonTest.Tables
{
    public class CategoriesTable : Table<Category>
    {
        public CategoriesTable(int id) : base(id)
        {

        }

        public CategoriesTable(int id, String name) : base(id, name)
        {

        }
    }
}

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
        public CategoriesTable() : base() { }
        public CategoriesTable(int id) : base(id) { }
        public CategoriesTable(int id, String name) : base(id, name) { }

        public override void ConnectionsSubload(TableCollection tablesCollection)
        {
            Table<Film> filmsTable = tablesCollection.GetTable<Film>();

            foreach (Category category in this)
            {
                while (category.Films.Count != 0)
                {
                    category.Films.Remove(category.Films[0]);
                }
            }

            foreach (Film film in filmsTable)
            {
                if (film.FranshiseId != 0)
                {
                    foreach (Category category in this)
                    {
                        if (film.FranshiseId == category.ID)
                        {
                            category.Films.Add(film);
                        }
                    }
                }
            }
        }
    }
}

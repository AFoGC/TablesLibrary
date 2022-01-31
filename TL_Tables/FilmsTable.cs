using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Table;
using TL_Objects;

namespace TL_Tables
{
	public class FilmsTable : Table<Film>
	{
		public override void ConnectionsSubload(TableCollection tablesCollection)
		{
			Table<Genre> genresTable = tablesCollection.GetTable<Genre>();
			foreach (Film film in this)
			{
				if (film.GenreId != 0)
				{
					foreach (Genre genre in genresTable)
					{
						if (film.GenreId == genre.ID)
						{
							film.Genre = genre;
							break;
						}
					}
				}
				else
				{
					film.Genre = genresTable.DefaultCell;
				}
			}
		}
	}
}

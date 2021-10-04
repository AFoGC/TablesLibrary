using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Tables;

namespace TablesLibraryTests.ACommonTest
{
	public static class MainInfo
	{
		private static TableCollection tabColl;
		public static TableCollection TableCollection
		{
			get { return tabColl; }
		}

		static MainInfo()
		{
			tabColl = new TableCollection();

			tabColl.AddTable(Tables.CategoriesTable);
			tabColl.AddTable(Tables.GenresTable);
			tabColl.AddTable(Tables.FilmsTable);
			tabColl.AddTable(Tables.SeriesTable);
		}

		public static class Tables
		{
			private static CategoriesTable categoriesTable;
			private static GenresTable genresTable;
			private static FilmsTable filmsTable;
			private static SeriesTable seriesTable;

			public static CategoriesTable CategoriesTable { get { return categoriesTable; } }
			public static GenresTable GenresTable { get { return genresTable; } }
			public static FilmsTable FilmsTable { get { return filmsTable; } }
			public static SeriesTable SeriesTable { get { return seriesTable; } }

			static Tables()
			{
				categoriesTable = new CategoriesTable(1);
				genresTable = new GenresTable(2);
				filmsTable = new FilmsTable(3);
				seriesTable = new SeriesTable(4);
			}
		}
	}
}

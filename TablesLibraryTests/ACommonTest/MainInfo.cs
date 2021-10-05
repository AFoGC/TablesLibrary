using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;
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

			Tables.Initialize();
		}

		public static class Tables
		{
			private static CategoriesTable categoriesTable;
			private static GenresTable genresTable;
			private static FilmsTable filmsTable;
			private static SeriesTable seriesTable;


			static Tables()
            {
				categoriesTable = new CategoriesTable();
				genresTable = new GenresTable();
				filmsTable = new FilmsTable();
				seriesTable = new SeriesTable();

				TableCollection.AddTable(categoriesTable);
				TableCollection.AddTable(genresTable);
				TableCollection.AddTable(filmsTable);
				TableCollection.AddTable(seriesTable);
			}

			public static void Initialize() { }

			public static CategoriesTable CategoriesTable { get { return categoriesTable; } }
			public static GenresTable GenresTable { get { return genresTable; } }
			public static FilmsTable FilmsTable { get { return filmsTable; } }
			public static SeriesTable SeriesTable { get { return seriesTable; } }
		}
	}
}

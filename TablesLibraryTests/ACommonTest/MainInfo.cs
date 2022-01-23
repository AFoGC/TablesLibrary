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
			private static GenresTable genresTable;
			private static FilmsTable filmsTable;


			static Tables()
            {
				genresTable = new GenresTable();
				filmsTable = new FilmsTable();

				TableCollection.AddTable(genresTable);
				TableCollection.AddTable(filmsTable);
			}

			public static void Initialize() { }

			public static GenresTable GenresTable { get { return genresTable; } }
			public static FilmsTable FilmsTable { get { return filmsTable; } }
		}
	}
}

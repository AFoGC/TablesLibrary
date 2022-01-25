using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibraryTests.ACommonTest.Cells;

namespace TablesLibraryTests.ACommonTest
{
	[TestClass()]
	public class MainTest
	{
		[TestMethod()]
		public void Main()
		{
            MainInfo.TableCollection.TableLoad += TableCollection_TableLoad;
			MainInfo.TableCollection.TableFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Testy.fdbc";
			MainInfo.TableCollection.FileEncoding = Encoding.UTF8;

			//Fill();
			MainInfo.TableCollection.LoadTables();
			MainInfo.TableCollection.SaveTables();

			Assert.IsTrue(true);
		}

        private void TableCollection_TableLoad(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        static void Fill()
        {
			Genre genre = new Genre();
			genre.Name = "Film";
			genre.IsSerial = false;
			MainInfo.Tables.GenresTable.AddElement(genre);

			Genre genre1 = new Genre();
			genre1.Name = "Serie";
			genre1.IsSerial = true;
			MainInfo.Tables.GenresTable.AddElement(genre1);



			Film film = new Film();
			film.Name = "Большой Лебовский";
			film.Genre = genre;
			film.RealiseYear = 1998;
			film.Watched = true;
			film.WatchDate = DateTime.Today;
			MainInfo.Tables.FilmsTable.AddElement(film);

			Film film1 = new Film();
			film1.Name = "Форест Гамп";
			film1.Genre = genre;
			film1.RealiseYear = 1994;
			MainInfo.Tables.FilmsTable.AddElement(film1);

			Film film2 = new Film();
			film2.Name = "Во все тяжкие";
			film2.Genre = genre1;
			film2.RealiseYear = 2008;
			MainInfo.Tables.FilmsTable.AddElement(film2);
		}
	}
}

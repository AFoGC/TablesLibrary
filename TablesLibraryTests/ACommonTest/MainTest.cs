using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;

namespace TablesLibraryTests.ACommonTest
{
	[TestClass()]
	public class MainTest
	{
		[TestMethod()]
		public void Main()
		{
			//TableCollection collection = 
			MainInfo.TableCollection.TableFilePath = @"F:\filmsDirectory\Testy.fdbc";
			MainInfo.TableCollection.LoadTables();
			MainInfo.TableCollection.ConnectionsSubload();
			MainInfo.TableCollection.TableFilePath = @"F:\filmsDirectory\Save.fdbc";
			MainInfo.TableCollection.SaveTables();

			Assert.IsTrue(true);
		}

		static void Fill()
        {

        }
	}
}

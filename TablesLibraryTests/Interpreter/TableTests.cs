using Microsoft.VisualStudio.TestTools.UnitTesting;
using TablesLibrary.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibraryTests.TestFilmClasses;

namespace TablesLibrary.Interpreter.Tests
{
	[TestClass()]
	public class TableTests
	{
		[TestMethod()]
		public void addVoidElementTest()
		{
			Table table = new Table(1, "defaltName", typeof(Cell));

			table.addElement();
			table.addElement();
			table.addElement();


			int i = 0;
			foreach (Cell cell in table.Cells)
			{
				Assert.AreEqual(++i, cell.ID);
			}
		}

		[TestMethod()]
		public void addElementWithParamTest()
		{
			Table table = new Table(typeof(TestCell1));

			TestCell1 testCell1 = new TestCell1();
			testCell1.Mark = 10;
			testCell1.Name = "Neme";
			testCell1.Watched = true;

			table.addElement();
			bool assert = table.addElement(testCell1);
			Assert.IsTrue(assert);
		}


		[TestMethod()]
		public void UpdateElementTest()
		{
			Table table = new Table(typeof(TestCell1));

			table.addElement();
			table.addElement();
			table.addElement();

			TestCell1 testCell1 = new TestCell1(3);
			TestCell2 testCell2 = new TestCell2(2);

			Assert.IsTrue(table.UpdateElement(testCell1));
			Assert.IsFalse(table.UpdateElement(testCell2));
		}
	}
}
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
    public class TableCollectionTests
    {
        [TestMethod()]
        public void AddTableTest()
        {
            TableCollection collection = new TableCollection();
            collection.AddTable(typeof(TestCell1));
            collection.AddTable(typeof(TestCell2));

            Table table = new Table(1, typeof(TestCell1));

            table.addElement();
            table.addElement();

            Assert.IsTrue(collection.UpdateTable(table));

            Table tableWrong = new Table(2, typeof(TestCell1));

            Assert.IsFalse(collection.UpdateTable(tableWrong));
        }
    }
}
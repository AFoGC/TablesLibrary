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
    public class CellTests
    {
        [TestMethod()]
        public void DateConvertation()
        {
            DateTime dateTime = DateTime.Today;

            String str = Cell.formatToString(dateTime);

            Assert.AreEqual(dateTime, Cell.readDate(str));
        }

        [TestMethod()]
        public void UpdateThis()
        {
            TestCell1 testCell1 = new TestCell1();
            TestCell1 testCell2 = new TestCell1(2);

            Assert.IsTrue(testCell2.UpdateThis(testCell1));
            
            //Assert.ThrowsException
        }
    }
}
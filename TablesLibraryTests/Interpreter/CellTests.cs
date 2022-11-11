using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void FormatParamFull()
        {
            String str = Cell.FormatParam(nameof(Int32), 10, 0, 2);
            String srt1 = "\t\t<Int32: 10>\n";
            Assert.AreEqual(str, srt1);
        }

        [TestMethod]
        public void FormatParamEmpty()
        {
            String str = Cell.FormatParam(nameof(Int32), 1, 1, 2);
            Assert.AreEqual(str, "");
        }

        [TestMethod()]
        public void UpdateThis()
        {
            
        }
    }
}
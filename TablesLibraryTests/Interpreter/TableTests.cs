using Microsoft.VisualStudio.TestTools.UnitTesting;
using TablesLibrary.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void addElementTest()
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
    }
}
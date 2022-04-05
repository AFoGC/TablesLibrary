using Microsoft.VisualStudio.TestTools.UnitTesting;
using TablesLibrary.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL_Tables;

namespace TablesLibrary.Interpreter.Tests
{
    [TestClass()]
    public class TableCollectionTests
    {
        [TestMethod()]
        public void AddTableTest()
        {
            
        }

        [TestMethod()]
        public void GetTableCollectionFromTalbe()
        {
            FilmsTable filmsTable = new FilmsTable();
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(filmsTable);
            Assert.AreEqual(tableCollection, filmsTable.TableCollection);
            Assert.IsTrue(tableCollection == filmsTable.TableCollection);
        }

        [TestMethod()]
        public void RemoveTableFrom()
        {
            FilmsTable filmsTable = new FilmsTable();
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(filmsTable);
            Assert.AreEqual(tableCollection, filmsTable.TableCollection);
            tableCollection.RemoveTable(filmsTable);
            Assert.IsNull(filmsTable.TableCollection);
        }
    }
}
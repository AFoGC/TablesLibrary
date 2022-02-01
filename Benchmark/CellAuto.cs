using Benchmark.XML_TL;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Table;
using TL_Objects;
using TL_Tables;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class CellAuto
    {
        private TableCollection AT;
        private TableCollection ST;
        private TableCollection SST;
        private XML_TL.XML_TL_Collection XML;

        public CellAuto()
        {
            AT = new TableCollection();
            AT.AddTable(new AutoTable());
            AT.FileEncoding = Encoding.UTF8;
            AT.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InAutoTest.fdbc";
            AT.LoadTables();
            AT.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutAutoTest.fdbc";

            ST = new TableCollection();
            ST.AddTable(new ScriptTable());
            ST.FileEncoding = Encoding.UTF8;
            ST.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InScriptTest.fdbc";
            ST.LoadTables();
            ST.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutScriptTest.fdbc";

            SST = new TableCollection();
            SST.AddTable(new StaticScriptTable());
            SST.FileEncoding = Encoding.UTF8;
            SST.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InStaticScriptTest.fdbc";
            SST.LoadTables();
            SST.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutStaticScriptTest.fdbc";

            XML = new XML_TL_Collection();
            Table<StaticScriptSaveCell> table = SST.GetTable<StaticScriptSaveCell>();
            XML.staticScriptSaveCells = new List<StaticScriptSaveCell>();
            foreach (StaticScriptSaveCell cell in table)
            {
                XML.staticScriptSaveCells.Add(cell);
            }
        }

        [Benchmark]
        public void AutoTableBenchmark()
        {
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(new AutoTable());
            tableCollection.FileEncoding = Encoding.UTF8;
            tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InAutoTest.fdbc";
            tableCollection.LoadTables();
            //tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutAutoTest.fdbc";
            //tableCollection.SaveTables();
        }

        [Benchmark]
        public void ScriptTableBenchmark()
        {
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(new ScriptTable());
            tableCollection.FileEncoding = Encoding.UTF8;
            tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InScriptTest.fdbc";
            tableCollection.LoadTables();
            //tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutScriptTest.fdbc";
            //tableCollection.SaveTables();
        }

        [Benchmark]
        public void StaticScriptTableBenchmark()
        {
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(new StaticScriptTable());
            tableCollection.FileEncoding = Encoding.UTF8;
            tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InStaticScriptTest.fdbc";
            tableCollection.LoadTables();
            //tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutStaticAutoTest.fdbc";
            //tableCollection.SaveTables();
        }

        [Benchmark]
        public void SaveAutoTableBenchmark()
        {
            AT.SaveTables();
        }

        [Benchmark]
        public void SaveScriptTableBenchmark()
        {
            ST.SaveTables();
        }

        [Benchmark]
        public void SaveStaticScriptTableBenchmark()
        {
            SST.SaveTables();
        }

        [Benchmark]
        public void XMLSerialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(XML_TL_Collection));
            using (StreamWriter fs = new StreamWriter(@"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\XMLTestOut.xml", false, Encoding.UTF8))
            {
                formatter.Serialize(fs, XML);
            }
        }

        [Benchmark]
        public void XMLDeSerialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(XML_TL_Collection));
            using (StreamReader fs = new StreamReader(@"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\XMLTestIn.xml", Encoding.UTF8))
            {
                XML = (XML_TL_Collection)formatter.Deserialize(fs);
            }
        }
    }
}

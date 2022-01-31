using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TablesLibrary.Interpreter;
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
            AT.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutScriptTest.fdbc";

            SST = new TableCollection();
            SST = new TableCollection();
            SST.AddTable(new ScriptTable());
            SST.FileEncoding = Encoding.UTF8;
            SST.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\InStaticScriptTest.fdbc";
            SST.LoadTables();
            AT.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\OutStaticScriptTest.fdbc";
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
    }
}

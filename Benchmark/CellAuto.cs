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
        [Benchmark]
        public void AutoTableBenchmark()
        {
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(new AutoTable());
            tableCollection.FileEncoding = Encoding.UTF8;
            tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\AutoTest.fdbc";
            tableCollection.LoadTables();
        }

        [Benchmark]
        public void ScriptTableBenchmark()
        {
            TableCollection tableCollection = new TableCollection();
            tableCollection.AddTable(new ScriptTable());
            tableCollection.FileEncoding = Encoding.UTF8;
            tableCollection.TableFilePath = @"F:\Prog\C#\projects\TablesLibrary\Benchmark\bin\Release\ScriptTest.fdbc";
            tableCollection.LoadTables();
        }
    }
}

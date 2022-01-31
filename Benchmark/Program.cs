using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CellAuto>();
            //CellAuto auto = new CellAuto();
            //auto.AutoTableBenchmark();
            //auto.ScriptTableBenchmark();
            //auto.StaticScriptTableBenchmark();
        }
    }
}

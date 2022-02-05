using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public delegate void TableEventHandler(object sender, EventArgs e);
    public class RemoveCellTableEventArgs : EventArgs
    {
        public Cell RemovedCell { get; internal set; }
    }
}

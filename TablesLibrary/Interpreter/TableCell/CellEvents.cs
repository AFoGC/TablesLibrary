using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.TableCell
{
    public delegate void CellEventHandler(object sender, EventArgs e);
    public class RemovedCellEventArgs : EventArgs
    {
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public interface IBaseTable
    {
        bool Remove(Cell remove);
        bool AddElement(Cell cell);
        bool AddElement();
    }
}

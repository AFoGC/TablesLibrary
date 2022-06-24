using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public interface ITable : INotifyCollectionChanged
    {
        int ID { get; }
        string Name { get; set; }
        int Count { get; }
        TableCollection TableCollection { get; }
        Type DataType { get; }
        bool Remove(Cell remove);
        bool AddElement(Cell cell);
    }
}

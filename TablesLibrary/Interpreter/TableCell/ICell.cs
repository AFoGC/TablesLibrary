using System;
using System.ComponentModel;
using TablesLibrary.Interpreter.Table;

namespace TablesLibrary.Interpreter.TableCell
{
    public interface ICell : INotifyPropertyChanged
    {
        int ID { get; }
        ITable ParentTable { get; }
        event EventHandler CellRemoved;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Table;
using TL_Objects;

namespace TL_Tables
{
    public class ScriptTable : Table<ScriptSaveCell>
    {
        public override void ConnectionsSubload(TableCollection tablesCollection)
        {
            //throw new NotImplementedException();
        }
    }
}

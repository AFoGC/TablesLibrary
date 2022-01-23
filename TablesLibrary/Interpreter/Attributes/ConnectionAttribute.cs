using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class ConnectionAttribute : Attribute
    {
        public String PropertyName { get; private set; }
    }
}

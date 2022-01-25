using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.TableCell
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        public String FieldName { get; private set; }
        public FieldAttribute(String fieldName)
        {
            this.FieldName = fieldName;
        }
    }
}

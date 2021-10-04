using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        private String fieldName;
        public String FieldName
        {
            get { return fieldName; }
        }

        public FieldAttribute(String fieldName)
        {
            this.fieldName = fieldName;
        }
    }
}

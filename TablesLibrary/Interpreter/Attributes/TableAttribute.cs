using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private String tableName;
        public String TableName
        {
            get { return tableName; }
        }

        TableAttribute(String tableName)
        {
            this.tableName = tableName;
        }
    }
}

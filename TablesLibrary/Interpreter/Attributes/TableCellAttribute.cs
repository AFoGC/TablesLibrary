using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TableCellAttribute : Attribute
	{
		Boolean isAutoSave;
		String dataSavename;

		public String DataSaveName
        {
            get { return dataSavename; }
        }

		public Boolean IsAutoSave
        {
            get { return isAutoSave; }
        }


		public TableCellAttribute(String dataSavename, Boolean isAutoSave)
        {
			this.dataSavename = dataSavename;
			this.isAutoSave = isAutoSave;
        }

		public TableCellAttribute(String dataSavename)
		{
			this.dataSavename = dataSavename;
			this.isAutoSave = false;
		}
	}
}

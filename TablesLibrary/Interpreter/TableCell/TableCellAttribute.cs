using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.TableCell
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TableCellAttribute : Attribute
	{
		public String DataSaveName { get; private set; }

		public Boolean IsAutoSave { get; private set; }


		public TableCellAttribute(String dataSavename, Boolean isAutoSave)
        {
			this.DataSaveName = dataSavename;
			this.IsAutoSave = isAutoSave;
        }

		public TableCellAttribute(String dataSavename)
		{
			this.DataSaveName = dataSavename;
			this.IsAutoSave = false;
		}
	}
}

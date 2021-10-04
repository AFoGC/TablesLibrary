using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CellAttribute : Attribute
	{
		Boolean isAutoSave;

        CellAttribute(Boolean isAutoSave)
        {
			this.isAutoSave = isAutoSave;
        }
	}
}

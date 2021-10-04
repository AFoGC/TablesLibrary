using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibraryTests.ACommonTest.Cells.CellDataClasses
{
	public class Source
	{
		public String name = "";
		public String sourceUrl = "";

		public Source()
		{

		}

		public Source(String sourceUrl)
		{
			this.sourceUrl = sourceUrl;
		}

		public Source(String name, String sourceUrl)
		{
			this.name = name;
			this.sourceUrl = sourceUrl;
		}

		public static Source ToSource(String import)
		{
			int komaIndex = import.IndexOf(',');
			if (komaIndex == -1)
			{
				return new Source(import);
			}
			else
			{
				return new Source(import.Substring(0, komaIndex), import.Substring(komaIndex + 2));
			}
		}

		public override string ToString()
		{
			if (name == "")
			{
				return sourceUrl;
			}
			else
			{
				return name + ", " + sourceUrl;
			}
		}
	}
}

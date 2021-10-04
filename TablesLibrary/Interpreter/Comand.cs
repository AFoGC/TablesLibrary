using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter
{
	public class Comand
	{
		private String parametr;
		private String argument;
		private bool isComand;

		public String Paramert
		{
			get { return parametr; }
		}

		public String Value
		{
			get { return argument; }
		}

		public bool IsComand
		{
			get { return isComand; }
		}

		public Comand()
		{

		}

		public Comand(String parametr, String argument, bool isComand)
		{
			this.parametr = parametr;
			this.argument = argument;
			this.isComand = isComand;
		}


		private void setComand(String parametr, String argument, bool isComand)
		{
			this.parametr = parametr;
			this.argument = argument;
			this.isComand = isComand;
		}

		public void getComand(String import)
		{
			bool isComand = false;
			String param = "";
			int i = 0;
			int n = import.Length;
			for (; i < n; i++)
			{
				if (import[i] == '<')
				{
					isComand = true;
					++i;
					break;
				}
			}

			if (isComand == false)
			{
				setComand("", "", isComand);
				return;
			}

			for (; i < n; i++)
			{
				switch (import[i])
				{
					case ':':
						i += 2;
						getArgument(import, param, i);
						return;
					case '>':
						setComand(param, "", true);
						return;
					default:
						param = param + import[i];
						break;
				}
			}

			setComand("", "", false);
			return;
		}

		private void getArgument(String import, String param, int i)
		{
			String arg = "";
			for (; i < import.Length; i++)
			{
				if (import[i] == '>')
				{
					setComand(param, arg, true);
					return;
				}
				else
				{
					arg = arg + import[i];
				}
			}

			setComand("", "", false);
			return;
		}
	}
}

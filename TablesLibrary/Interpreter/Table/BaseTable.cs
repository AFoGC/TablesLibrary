using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public abstract class BaseTable
	{
        protected int id = 0;
        protected String name = "";

		public int ID
		{
			get { return id; }
            set
            {
                if (id == 0)
                {
                    id = value;
                }
                else
                {
                    throw new Exception("Cant change id if it != 0");
                }
            }
		}

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

        private TableCollection tableCollection;
        public TableCollection TableCollection
        {
            get
            {
                return tableCollection;
            }
            internal set
            {
                if (tableCollection != null && value != tableCollection)
                {
                    id = 0;
                }
                tableCollection = value;
            }
        }

        internal void InCollectionChanged()
        {
            TableCollection.TableChanged();
        }

        public abstract void SaveTable(StreamWriter streamWriter);
		public abstract void LoadTable(StreamReader streamReader, Comand comand);
        public abstract void ConnectionsSubload(TableCollection tablesCollection);
        public abstract Type DataType { get; }
    }
}

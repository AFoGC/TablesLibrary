using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TablesLibrary.Interpreter.Table
{
    public abstract class BaseTable : INotifyCollectionChanged, INotifyPropertyChanged
    {
        protected int id = 0;
        
        protected String name = "";

        public int ID
		{
			get => id;
            internal set => id = value;
		}

		public String Name
		{
			get => name;
			set => name = value;
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

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            InCollectionChanged();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void InCollectionChanged()
        {
            TableCollection.TableChanged();
        }

        public abstract void SaveTable(StreamWriter streamWriter);
		public abstract void LoadTable(StreamReader streamReader, Comand comand);
        public abstract void ConnectionsSubload(TableCollection tablesCollection);
        public virtual void PresaveChages(TableCollection tablesCollection) { }

        public abstract Type DataType { get; }
    }
}

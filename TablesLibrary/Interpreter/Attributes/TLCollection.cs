using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.Attributes
{
    public class TLCollection<T> : IEnumerable where T : Cell, new()
    {
        private List<T> elements;
        public TLCollection()
        {
            elements = new List<T>();
        }

        public T this[int i]
        {
            get { return elements[i]; }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnu();
        }

        private TableEnum<T> GetEnu()
        {
            return new TableEnum<T>(elements);
        }



        private class TableEnum : IEnumerator
        {
            private List<T> list;
            private int position = -1;

            public TableEnum(List<T> table)
            {
                this.list = table;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public T Current
            {
                get
                {
                    return list[position];
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < list.Count);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesLibrary.Interpreter.TableCell
{
	public class TLCollection<T> : IList<T>
	{
		private List<T> collection;

        public event TLCollectionEventHandler CollectionChanged;

        public TLCollection() { collection = new List<T>(); }

		public T this[int index]
		{ 
			get => collection[index];
			set
			{
				collection[index] = value;
			}
		}

		public int Count => collection.Count;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			collection.Add(item);
		}

		public void Clear()
		{
			collection.Clear();
		}

		public bool Contains(T item)
		{
			return collection.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			collection.CopyTo(array, arrayIndex);
		}

		public int IndexOf(T item)
		{
			return collection.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			collection.Insert(index, item);
		}

		public bool Remove(T item)
		{
			bool removed = collection.Remove(item);
            if (removed)
            {

            }
			return removed;
		}

		public void RemoveAt(int index)
		{
			collection.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return collection.GetEnumerator();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
				OnCollectionChanged();
			}
		}

		public int Count => collection.Count;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			collection.Add(item);
			OnCollectionChanged();
		}

		public void Clear()
		{
			collection.Clear();
			OnCollectionChanged();
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
			OnCollectionChanged();
		}

		public bool Remove(T item)
		{
			bool removed = collection.Remove(item);
            if (removed)
            {
				OnCollectionChanged();
			}
			return removed;
		}

		public void RemoveAt(int index)
		{
			collection.RemoveAt(index);
			OnCollectionChanged();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		public void OnCollectionChanged()
		{
			TLCollectionEventHandler handler = CollectionChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}
    }
}

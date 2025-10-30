using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoCollections.Collections
{
    internal class MyList<T> : IEnumerable<T> where T : IDisposable
    {
        private LinkedList<T> _store;
        private int count;

        public MyList()
        {
            _store = new LinkedList<T>();
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            _store.AddLast(item);
            count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            if (index == count)
            {
                _store.AddLast(item);
            }
            else
            {
                var current = _store.First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                _store.AddBefore(current, item);
            }
            count++;
        }

        public bool Remove(T item)
        {
            var node = _store.Find(item);
            if (node != null)
            {
                _store.Remove(node);
                count--;
                return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator() //iterator
        {
            return _store.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _store.GetEnumerator();
        }

        public T this[int index] //indexer
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                var current = _store.First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                var current = _store.First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }
    }
}

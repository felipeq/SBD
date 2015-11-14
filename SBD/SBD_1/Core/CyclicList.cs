using System;
using System.Collections;
using System.Collections.Generic;

namespace SBD_1.Core
{
    public class CyclicList<T> : IEnumerable<T>, IEnumerator<T> where T : Tape
    {
        private readonly List<T> _items = new List<T>();
        private int _index = -1;
        public void Add(T item)
        {
            _items.Add(item);
        }

        public double LastValue
        {
            get
            {
                return _items[Index].LastValue;
            }
        }

        internal void Add(double val)
        {
            _items[Index].Append(val);
        }

        internal void ChangeToNextAndAdd(int val)
        {
            MoveNext();
            Add(val);
        }
        public T Value
        {
            get { return _items[Index]; }
            set { _items[Index] = value; }
        }

        private T this[int index]
        {
            get
            {
                RangeCheck(index);
                return _items[index];
            }
        }

        private void RangeCheck(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Indexer cannot be less than 0.");
            }

            if (index >= _items.Count)
            {
                throw new ArgumentOutOfRangeException("Indexer cannot be greater than or equal to the number of items in the collection.");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public T Current
        {
            get { return this[Index]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return this[Index]; }
        }

        public int Index
        {
            get { return _index; }
        }

        public bool MoveNext()
        {
            _index = Index + 1;
            if (Index == _items.Count)
            {
                Reset();
                return true;
            }

            return false;
        }
        public void Reset()
        {
            _index = 0;
        }

        public bool IsFirstRun()
        {
            if (Index == -1)
            {
                _index = 0;
                return true;
            }
            else
                return false;

        }
    }
}

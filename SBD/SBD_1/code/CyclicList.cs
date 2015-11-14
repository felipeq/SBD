using System;
using System.Collections;
using System.Collections.Generic;

namespace SBD_1.code
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
                return _items[_index].LastValue;
            }
        }

        internal void Add(double val)
        {
            _items[_index].Add(val);
        }

        internal void ChangeToNextAndAdd(int val)
        {
            MoveNext();
            Add(val);
        }
        public T Value
        {
            get { return _items[_index]; }
            set { _items[_index] = value; }
        }
        public T this[int index]
        {
            get
            {
                RangeCheck(index);
                return _items[index];
            }
            set
            {
                RangeCheck(index);
                _items[index] = value;
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
            get { return this[_index]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return this[_index]; }
        }
        public bool MoveNext()
        {
            ++_index;
            if (_index == _items.Count)
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
            if (_index == -1)
            {
                _index = 0;
                return true;
            }
            else
                return false;

        }
    }
}

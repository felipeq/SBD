using SBD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBD_1.code
{
    public class CyclicList<T> : IEnumerable<T>, IEnumerator<T> where T : Tape
    {
        protected List<T> items = new List<T>();
        protected int index = 0;
        public void Add(T item)
        {
            items.Add(item);
        }

        public double LastValue
        {
            get
            {
                return items[index].LastValue;
            }
        }

        internal void Add(double val)
        {
            items[index].Add(val);
        }

        internal void ChangeToNextAndAdd(int val)
        {
            MoveNext();
            Add(val);
        }
        public T Value
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        public T this[int index]
        {
            get
            {
                RangeCheck(index);
                return items[index];
            }
            set
            {
                RangeCheck(index);
                items[index] = value;
            }
        }
        protected void RangeCheck(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                   "Indexer cannot be less than 0.");
            }

            if (index >= items.Count)
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
            get { return this[index]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return this[index]; }
        }
        public bool MoveNext()
        {
            ++index;
            bool ret = index < items.Count;

            if (!ret)
            {
                Reset();
            }

            return ret;
        }
        public void Reset()
        {
            index = -1;
        }
    }
}

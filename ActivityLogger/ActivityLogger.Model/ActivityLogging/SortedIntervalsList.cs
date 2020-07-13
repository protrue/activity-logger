using System;
using System.Collections;
using System.Collections.Generic;

namespace ActivityLogger.Model.ActivityLogging
{
    public class SortedIntervalsList<T> : IList<IInterval<T>> where T : IComparable<T>
    {
        public IEnumerator<IInterval<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IInterval<T> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IInterval<T> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IInterval<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IInterval<T> item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(IInterval<T> item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IInterval<T> item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public IInterval<T> this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}

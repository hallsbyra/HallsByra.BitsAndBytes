using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    /// The virtual list acts as a facade over one ore more other lists in sequence. Requests to the virtual list is routed to 
    /// one of the underlying lists.
    /// 
    /// TODO: Rework into a pure binary tree implementation. Each VirtualList should hold only two sublists.
    public class VirtualList<T> : IList<T>
    {
        private readonly IList<T>[] backingLists;


        public VirtualList(IList<T> first, IList<T> second)
        {
            this.backingLists = new[] { first, second };
        }

        public VirtualList(IEnumerable<IList<T>> backingLists)
        {
            this.backingLists = backingLists.ToArray();
        }

        public VirtualList(params IList<T>[] backingLists)
        {
            this.backingLists = backingLists;
        }

        public int IndexOf(T item)
        {
            for (int index = 0; index <= Count; index++)
                if (this[index].Equals(item))
                    return index;
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public T this[int index]
        {
            get
            {
                int indexInList;
                var list = FindListForIndex(index, out indexInList);
                return list[indexInList];
            }
            set
            {
                int indexInList;
                var list = FindListForIndex(index, out indexInList);
                list[indexInList] = value;
            }
        }

        private IList<T> FindListForIndex(int index, out int indexInList)
        {
            int indexAtListEnd = 0;
            foreach(var list in backingLists)
            {
                int count = list.Count;
                indexAtListEnd += count;
                if(indexAtListEnd > index)
                {
                    indexInList = index - (indexAtListEnd - count);
                    return list;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public void Clear()
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public bool Contains(T item)
        {
            return backingLists.SelectMany(l => l).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            backingLists.Each(l =>
                {
                    l.CopyTo(array, arrayIndex);
                    arrayIndex += l.Count;
                });
        }

        public int Count
        {
            get 
            {
                return backingLists.Sum(l => l.Count);
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return backingLists.SelectMany(l => l).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
